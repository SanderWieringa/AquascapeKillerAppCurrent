using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL_Factory
{
    public static class PlantDalFactory
    {
        public static IPlantCollectionRepository CreatePlantCollectionRepository()
        {
            return new PlantRepository(new PlantSqlContext());
        }
    }
}
