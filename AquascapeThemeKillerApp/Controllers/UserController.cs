using AquascapeThemeKillerApp.Logic_Factory;
using AquascapeThemeKillerApp.Logic_Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AquascapeThemeKillerApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IPlantCollection _plantCollectionLogic = PlantLogicFactory.CreatePlantCollection();
        private readonly IFishCollection _fishCollectionLogic = FishLogicFactory.CreateFishCollection();
        private readonly IAquascape _aquascapeLogic = AquascapeLogicFactory.CreateAquascape();
        private readonly IAquascapeCollection _aquascapeCollection = AquascapeLogicFactory.CreateAquascapeCollection();

        
    }
}