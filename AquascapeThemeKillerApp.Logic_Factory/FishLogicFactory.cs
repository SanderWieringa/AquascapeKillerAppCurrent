using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.Logic;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Logic_Factory
{
    public static class FishLogicFactory
    {
        public static IFishCollection CreateFishCollection()
        {
            return new FishCollection();
        }
    }
}
