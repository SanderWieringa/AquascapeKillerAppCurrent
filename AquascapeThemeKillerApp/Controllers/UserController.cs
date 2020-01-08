using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquascapeThemeKillerApp.Logic_Factory;
using AquascapeThemeKillerApp.Logic_Interfaces;
using AquascapeThemeKillerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AquascapeThemeKillerApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IPlantCollection _plantCollectionLogic = PlantLogicFactory.CreatePlantCollection();
        private readonly IFishCollection _fishCollectionLogic = FishLogicFactory.CreateFishCollection();
        private readonly IAquascape _aquascapeLogic = AquascapeLogicFactory.CreateAquascape();
        private readonly IAquascapeCollection _aquascapeCollection = AquascapeLogicFactory.CreateAquascapeCollection();

        public ActionResult Index()
        {
            var model = new AquascapeItemSelectionViewModel();

            foreach (var plant in _plantCollectionLogic.GetAllPlants())
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

            foreach (var fish in _fishCollectionLogic.GetAllFishes())
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

            AquascapeModel aquascapeModel = _aquascapeCollection.AssembleFishes(selectedFishes);

            return View(aquascapeModel);
        }

        [HttpPost]
        public ActionResult SubmitSelectedPlant(AquascapeItemSelectionViewModel model)
        {
            var selectedIds = model.GetSelectedPlantIds();

            var selectedPlants = (from plant in _plantCollectionLogic.GetAllPlants()
                where selectedIds.Contains(plant.PlantId)
                select plant).ToList();

            AquascapeModel aquascapeModel = _aquascapeCollection.AssemblePlants(selectedPlants);

            return View(aquascapeModel);
        }

        [HttpPost]
        public ActionResult CreateAquascape(AquascapeItemSelectionViewModel model)
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