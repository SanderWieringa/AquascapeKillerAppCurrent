using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquascapeThemeKillerApp.Logic_Factory;
using AquascapeThemeKillerApp.Logic_Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AquascapeThemeKillerApp.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantCollection _plantCollectionLogic = PlantLogicFactory.CreatePlantCollection();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllPlants()
        {
            return View(ConvertToPlantModelList());
        }

        private List<PlantModel> ConvertToPlantModelList()
        {
            List<PlantModel> plantModels = new List<PlantModel>();
            foreach (var plant in _plantCollectionLogic.GetAllPlants())
            {
                plantModels.Add(new PlantModel(plant));
            }

            return plantModels;
        }
    }
}