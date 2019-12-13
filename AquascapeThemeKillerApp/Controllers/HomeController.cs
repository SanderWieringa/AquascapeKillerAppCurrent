using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AquascapeThemeKillerApp.Models;
using AquascapeThemeKillerApp.Logic_Interfaces;
using AquascapeThemeKillerApp.Logic_Factory;
using java.lang;
using Amazon.OpsWorks.Model;

namespace AquascapeThemeKillerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAquascapeCollection _aquascapeCollectionLogic = AquascapeLogicFactory.CreateAquascapeCollection();
        private readonly IAquascape _aquascapeLogic = AquascapeLogicFactory.CreateAquascape();
        private readonly IManager _managerLogic = ManagerLogicFactory.CreateManager();

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
            catch (System.Exception ex)
            {
                throw new System.Exception("Something went wrong!", ex);
            }
        }

        [HttpGet]
        public IActionResult GetAllFishByAquascape(int aquascapeId)
        {
            try
            {
                return View(ConvertToFishModelList(1));
            }
            catch
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
            catch (NullPointerException ex)
            {
                Console.WriteLine(ex);
                TempData["Error"] = "Something went wrong!";
                return View("Error");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex);
                TempData["Error"] = "Something went wrong!";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult GenerateAquascape()
        {
            try
            {
                return View(_managerLogic.GenerateAquascape());
            }
            catch
            {
                return default;
            }
        }

        [HttpGet]
        public IActionResult GetAllAquascapes()
        {
            try
            {
                return View(ConvertToAquascapeModelList());
            }
            catch
            {
                return default;
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

        //public AquascapeModel ConvertGeneratedAquascapeModel()
        //{
        //    return _aquascapeLogic.GenerateAquascape();
        //}

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

        //private AquascapeModel ConvertToAquascapeModel(int aquascapeId)
        //{
        //    return _aquascapeCollectionLogic.GetAquascapeById(aquascapeId);
        //}
    }
}
