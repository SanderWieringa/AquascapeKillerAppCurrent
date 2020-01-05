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
                var editorViewModel = new SelectFishEditorViewModel()
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

            var selectedFishes = from fish in _fishCollectionLogic.GetAllFishes()
                where selectedIds.Contains(fish.FishId)
                select fish;

            

            foreach (var fish in selectedFishes)
            {
                System.Diagnostics.Debug.WriteLine("{0} {1} {2}", fish.FishName, fish.FishType, fish.FishSize);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SubmitSelectedPlant(AquascapeItemSelectionViewModel model)
        {
            var selectedIds = model.GetSelectedPlantIds();

            var selectedPlants = (from plant in _plantCollectionLogic.GetAllPlants()
                where selectedIds.Contains(plant.PlantId)
                select plant).ToList();

            _aquascapeCollection.AssemblePlants(selectedPlants);

            //foreach (var plant in selectedPlants)
            //{
            //    System.Diagnostics.Debug.WriteLine("{0} {1}", plant.PlantName, plant.Difficulty);
            //}

            return View();
        }
    }
}