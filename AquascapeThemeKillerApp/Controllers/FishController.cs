using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquascapeThemeKillerApp.Logic_Factory;
using AquascapeThemeKillerApp.Logic_Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AquascapeThemeKillerApp.Controllers
{
    public class FishController : Controller
    {
        private readonly IFishCollection _fishCollectionLogic = FishLogicFactory.CreateFishCollection();

        public IActionResult GetAllFishes()
        {
            return View(ConvertToFishModelList());
        }

        private List<FishModel> ConvertToFishModelList()
        {
            List<FishModel> fishModels = new List<FishModel>();
            foreach (var fish in _fishCollectionLogic.GetAllFishes())
            {
                fishModels.Add(new FishModel(fish));
            }

            return fishModels;
        }
    }
}