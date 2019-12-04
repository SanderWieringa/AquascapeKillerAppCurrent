using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL_Factory
{
    public static class FishDalFactory
    {
        public static IFishCollectionRepository CreateFishCollectionRepository()
        {
            return new FishRepository(new FishSqlContext());
        }
    }
}
