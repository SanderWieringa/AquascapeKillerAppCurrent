﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon.Runtime;
using AquascapeThemeKillerApp.Logic_Factory;
using AquascapeThemeKillerApp.Logic_Interfaces;
using AquascapeThemeKillerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AquascapeThemeKillerApp.Controllers
{
    public class AquascapeController : Controller
    {
        private readonly IPlantCollection _plantCollectionLogic = PlantLogicFactory.CreatePlantCollection();
        private readonly IFishCollection _fishCollectionLogic = FishLogicFactory.CreateFishCollection();
        private readonly IAquascapeAssembler _aquascapeLogic = AquascapeLogicFactory.CreateAquascapeAssembler();
        private readonly IAquascapeCollection _aquascapeCollection = AquascapeLogicFactory.CreateAquascapeCollection();

        private AquascapeItemSelectionViewModel _model;

        public ActionResult Index()
        {
            AquascapeModel aquascapeModel = _aquascapeLogic.CreateAquascape();
            aquascapeModel.Name = "aids";
            HttpContext.Session.SetObject("AquascapeObject", aquascapeModel);

           var meuk = HttpContext.Session.GetObject<AquascapeModel>("AquascapeObject");

            return View(aquascapeModel);
        }

        public ActionResult AddPlant()
        {
            _model = new AquascapeItemSelectionViewModel();

            foreach (IPlant plant in _plantCollectionLogic.GetAllPlants())
            {
                var editorViewModel = new SelectPlantEditorViewModel()
                {
                    Selected = false,
                    PlantId = plant.PlantId,
                    PlantName = plant.PlantName,
                    Difficulty = plant.Difficulty
                };
                _model.Plants.Add(editorViewModel);
            }

            return View(_model);
        }

        public ActionResult AddFish()
        {
            _model = new AquascapeItemSelectionViewModel();

            foreach (IFish fish in _fishCollectionLogic.GetAllFishes())
            {
                var editorViewModel = new SelectFishEditorViewModel
                {
                    Selected = false,
                    FishId = fish.FishId,
                    FishName = fish.FishName,
                    FishType = fish.FishType,
                    FishSize = fish.FishSize
                };
                _model.Fishes.Add(editorViewModel);
            }

            return View(_model);
        }

        public ActionResult CreateAquascape()
        {
            var model = new AquascapeItemSelectionViewModel();

            foreach (IPlant plant in _plantCollectionLogic.GetAllPlants())
            {
                var editorViewModel = new SelectPlantEditorViewModel()
                {
                    Selected = false,
                    PlantId = plant.PlantId,
                    PlantName = plant.PlantName,
                    Difficulty = plant.Difficulty
                };
                model.Plants.Add(editorViewModel);
            }

            foreach (IFish fish in _fishCollectionLogic.GetAllFishes())
            {
                var editorViewModel = new SelectFishEditorViewModel
                {
                    Selected = false,
                    FishId = fish.FishId,
                    FishName = fish.FishName,
                    FishType = fish.FishType,
                    FishSize = fish.FishSize
                };
                model.Fishes.Add(editorViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitSelectedFish(AquascapeItemSelectionViewModel model)
        {
            var selectedIds = model.GetSelectedFishIds();

            var selectedFishes = (from fish in _fishCollectionLogic.GetAllFishes()
                                  where selectedIds.Contains(fish.FishId)
                                  select fish).ToList();
             
             AquascapeModel aquascapeModel = _aquascapeLogic.AssembleFishes(selectedFishes);

             foreach (var fish in HttpContext.Session.GetObject<AquascapeModel>("AquascapeObject").FishInAquarium)
             {
                 aquascapeModel.FishInAquarium.Add(fish);
             }
             
             HttpContext.Session.SetObject("AquascapeObject", aquascapeModel);

            return View(aquascapeModel);
        }

        [HttpPost]
        public ActionResult SubmitSelectedPlant(AquascapeItemSelectionViewModel model)
        {
            var selectedIds = model.GetSelectedPlantIds();

            var selectedPlants = (from plant in _plantCollectionLogic.GetAllPlants()
                                  where selectedIds.Contains(plant.PlantId)
                                  select plant).ToList();

            //var sessionAquascapeModel = HttpContext.Session.GetObject<AquascapeModel>("AquascapeObject");
            AquascapeModel aquascapeModel= _aquascapeLogic.AssemblePlants(selectedPlants);

            foreach (var plant in HttpContext.Session.GetObject<AquascapeModel>("AquascapeObject").PlantsInAquarium)
            {
                aquascapeModel.PlantsInAquarium.Add(plant);
            }

            HttpContext.Session.SetObject("AquascapeObject", aquascapeModel);

            return View(aquascapeModel);
        }

        [HttpPost]
        public ActionResult Create(AquascapeItemSelectionViewModel model)
        {
            _aquascapeCollection.AddAquascape(ConvertSelectionViewModel(model));

            return default;
        }

        private static AquascapeModel ConvertSelectionViewModel(AquascapeItemSelectionViewModel model)
        {
            var aquascapeModel = new AquascapeModel
            {
                AquascapeId = model.AquascapeId,
                Name = model.AquascapeName,
                Difficulty = model.Difficulty
            };

            var plants = new List<IPlant>();
            foreach (SelectPlantEditorViewModel plant in model.Plants)
            {
                plants.Add(ConvertPlantViewModel(plant));
            }

            var fishes = new List<IFish>();
            foreach (SelectFishEditorViewModel fish in model.Fishes)
            {
                fishes.Add(ConvertFishViewModel(fish));
            }

            aquascapeModel.PlantsInAquarium = plants;
            aquascapeModel.FishInAquarium = fishes;

            return aquascapeModel;
        }

        private static FishModel ConvertFishViewModel(SelectFishEditorViewModel fishViewModel)
        {
            var fishModel = new FishModel
            {
                FishId = fishViewModel.FishId,
                FishName = fishViewModel.FishName,
                FishType = fishViewModel.FishType,
                FishSize = fishViewModel.FishSize
            };

            return fishModel;
        }

        private static PlantModel ConvertPlantViewModel(SelectPlantEditorViewModel plantViewModel)
        {
            var plantModel = new PlantModel
            {
                PlantId = plantViewModel.PlantId,
                PlantName = plantViewModel.PlantName,
                Difficulty = plantViewModel.Difficulty
            };

            return plantModel;
        }
    }
}