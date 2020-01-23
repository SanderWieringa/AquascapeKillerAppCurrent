using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AquascapeThemeKillerApp.Models;
using AquascapeThemeKillerApp.Logic_Interfaces;
using AquascapeThemeKillerApp.Logic_Factory;
using java.lang;
using Exception = java.lang.Exception;

namespace AquascapeThemeKillerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAquascapeCollection _aquascapeCollectionLogic = AquascapeLogicFactory.CreateAquascapeCollection();
        private readonly IAquascape _aquascapeLogic = AquascapeLogicFactory.CreateAquascape();
        private readonly IAquascapeGenerator _aquascapeGeneratorLogic = AquascapeGeneratorLogicFactory.CreateAquascapeGenerator();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllPlantsByAquascape(int aquascapeId)
        {
            try
            {
                return View(ConvertToPlantModelList(1));
            }
            catch (Exception e)
            {
                ViewBag.Message = "Something went wrong! Try again later.";
                return default;
            }
        }

        [HttpGet]
        public IActionResult GetAllFishByAquascape(int aquascapeId)
        {
            try
            {
                return View(ConvertToFishModelList(1));
            }
            catch(Exception e)
            {
                return default;
            }
        }

        [HttpGet]
        public IActionResult AquascapeDetails(int id)
        {
            try
            {
                return View(_aquascapeCollectionLogic.GetAquascapeById(id));
            }
            catch (NullPointerException e)
            {
                Console.WriteLine(e);
                TempData["Error"] = "Something went wrong!";
                return View("Error");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
                TempData["Error"] = "Something went wrong!";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult GenerateAquascape()
        {
            try
            {
                AquascapeItemSelectionViewModel aquascapeSelectionModel = ConvertAquascapeModel(_aquascapeGeneratorLogic.GenerateAquascape());
                HttpContext.Session.SetObject("AquascapeObject", aquascapeSelectionModel);
                return View(aquascapeSelectionModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult GetAllAquascapes()
        {
            try
            {
                return View(ConvertToAquascapeModelList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View("Error");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

        public List<AquascapeModel> ConvertToAquascapeModelList()
        {
            List<AquascapeModel> aquascapeModelList = new List<AquascapeModel>();

            foreach (var aquascape in _aquascapeCollectionLogic.GetAllAquascapes())
            {
                aquascapeModelList.Add(new AquascapeModel(aquascape));
            }

            return aquascapeModelList;
        }

        private List<PlantModel> ConvertToPlantModelList(int aquascapeId)
        {
            List<PlantModel> plantModelList = new List<PlantModel>();

            foreach (var plant in _aquascapeLogic.GetAllPlantsByAquascape(aquascapeId))
            {
                plantModelList.Add(new PlantModel(plant));
            }

            return plantModelList;
        }

        private List<FishModel> ConvertToFishModelList(int aquascapeId)
        {
            List<FishModel> fishModelList = new List<FishModel>();

            foreach (var fish in _aquascapeLogic.GetAllFishByAquascape(aquascapeId))
            {
                fishModelList.Add(new FishModel(fish));
            }

            return fishModelList;
        }
    }
}
