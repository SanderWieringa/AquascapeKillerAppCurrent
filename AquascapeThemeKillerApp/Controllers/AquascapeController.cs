using System;
using System.Collections.Generic;
using System.Linq;
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
        private AquascapeItemSelectionViewModel _aquascapeModel;
        private AquascapeItemSelectionViewModel _sessionAquascapeModel;
        private AquascapeItemSelectionViewModel _model;

        public ActionResult Index()
        {
            try
            {
                AquascapeModel aquascapeModel = _aquascapeLogic.CreateAquascape();
                HttpContext.Session.SetObject("AquascapeObject", aquascapeModel);

                return View(aquascapeModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.Message = "Something went wrong! Try again later.";
            }

            return RedirectToAction("GetAllAquascapes", "Home");
        }

        public ActionResult AddPlant()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.Message = "Something went wrong! Try again later.";
            }

            return RedirectToAction("GetAllAquascapes", "Home");
        }

        public ActionResult AddFish()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.Message = "Something went wrong! Try again later.";
            }

            return RedirectToAction("GetAllAquascapes", "Home");
        }

        public ActionResult CreateAquascape()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.Message = "Something went wrong! Try again later.";
            }

            return RedirectToAction("GetAllAquascapes", "Home");
        }

        [HttpPost]
        public ActionResult SubmitSelectedFish(AquascapeItemSelectionViewModel model)
        {
            try
            {
                var selectedIds = model.GetSelectedFishIds();

                var selectedFishes = (from fish in _fishCollectionLogic.GetAllFishes()
                    where selectedIds.Contains(fish.FishId)
                    select fish).ToList();

                _sessionAquascapeModel = HttpContext.Session.GetObject<AquascapeItemSelectionViewModel>("AquascapeObject");
                _aquascapeModel = ConvertAquascapeModel(_aquascapeLogic.AssembleFishes(selectedFishes, ConvertSelectionViewModel(_sessionAquascapeModel)));

                HttpContext.Session.SetObject("AquascapeObject", _aquascapeModel);

                return View(_aquascapeModel);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                ViewBag.Message = string.Format("{0}", e);
                return View(_sessionAquascapeModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(_sessionAquascapeModel);
            }
        }

        [HttpPost]
        public IActionResult SubmitSelectedPlant(AquascapeItemSelectionViewModel model)
        {
            try
            {
                var selectedIds = model.GetSelectedPlantIds();

                var selectedPlants = (from plant in _plantCollectionLogic.GetAllPlants()
                    where selectedIds.Contains(plant.PlantId)
                    select plant).ToList();

                _sessionAquascapeModel = HttpContext.Session.GetObject<AquascapeItemSelectionViewModel>("AquascapeObject");
                _aquascapeModel = ConvertAquascapeModel(_aquascapeLogic.AssemblePlants(selectedPlants, ConvertSelectionViewModel(_sessionAquascapeModel)));

                HttpContext.Session.SetObject("AquascapeObject", _aquascapeModel);

                return View(_aquascapeModel);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                ViewBag.Message = string.Format("{0}", e);
                return View(_sessionAquascapeModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View(_sessionAquascapeModel);
            }
        }

        [HttpPost]
        public ActionResult Create(AquascapeItemSelectionViewModel model) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _sessionAquascapeModel = HttpContext.Session.GetObject<AquascapeItemSelectionViewModel>("AquascapeObject");
                    _sessionAquascapeModel.AquascapeName = model.AquascapeName;
                    _aquascapeCollection.AddAquascape(ConvertSelectionViewModel(_sessionAquascapeModel));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    ViewBag.Message = "Something went wrong! Try again later.";
                }
                
            }

            return RedirectToAction("GetAllAquascapes", "Home");
        }

        private static AquascapeModel ConvertSelectionViewModel(AquascapeItemSelectionViewModel model)
        {
            var aquascapeModel = new AquascapeModel
            {
                AquascapeId = model.AquascapeId,
                Name = model.AquascapeName,
                Difficulty = model.Difficulty
            };

            var plantModels = new List<PlantModel>();
            foreach (SelectPlantEditorViewModel plant in model.Plants)
            {
                plantModels.Add(ConvertPlantViewModel(plant));
            }

            var fishModels = new List<FishModel>();
            foreach (SelectFishEditorViewModel fish in model.Fishes)
            {
                fishModels.Add(ConvertFishViewModel(fish));
            }

            aquascapeModel.PlantsInAquarium = plantModels;
            aquascapeModel.FishInAquarium = fishModels;

            return aquascapeModel;
        }

        private static AquascapeItemSelectionViewModel ConvertAquascapeModel(AquascapeModel model)
        {
            var aquascapeItemSelectionViewModel = new AquascapeItemSelectionViewModel
            {
                AquascapeId = model.AquascapeId,
                AquascapeName = model.Name,
                Difficulty = model.Difficulty
            };

            var plantModels = new List<SelectPlantEditorViewModel>();
            foreach (PlantModel plant in model.PlantsInAquarium)
            {
                plantModels.Add(ConvertPlantModel(plant));
            }

            var fishModels = new List<SelectFishEditorViewModel>();
            foreach (FishModel fish in model.FishInAquarium)
            {
                fishModels.Add(ConvertFishModel(fish));
            }

            aquascapeItemSelectionViewModel.Plants = plantModels;
            aquascapeItemSelectionViewModel.Fishes = fishModels;

            return aquascapeItemSelectionViewModel;
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

        private static SelectPlantEditorViewModel ConvertPlantModel(PlantModel plantModel)
        {
            var plantViewModel = new SelectPlantEditorViewModel
            {
                PlantId = plantModel.PlantId,
                PlantName = plantModel.PlantName,
                Difficulty = plantModel.Difficulty
            };

            return plantViewModel;
        }

        private static SelectFishEditorViewModel ConvertFishModel(FishModel fishModel)
        {
            var fishViewModel = new SelectFishEditorViewModel()
            {
                FishId = fishModel.FishId,
                FishName = fishModel.FishName,
                FishType = fishModel.FishType,
                FishSize = fishModel.FishSize
            };

            return fishViewModel;
        }
    }
}