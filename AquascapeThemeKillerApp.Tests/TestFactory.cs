using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Tests
{
    public static class TestFactory
    {
        public static IAquascapeCollectionRepository CreateMemoryAquascapeCollectionDAL()
        {
            return new AquascapeRepository(new AquascapeMemoryContext());
        }

        public static IAquascapeRepository CreateMemoryAquascapeDAL()
        {
            return new AquascapeRepository(new AquascapeMemoryContext());
        }

        public static IPlantCollectionRepository CreateMemoryPlantDal()
        {
            return new PlantRepository(new PlantMemoryContext());
        }

        public static IFishCollectionRepository CreateMemoryFishDal()
        {
            return new FishRepository(new FishMemoryContext());
        }
    }
}
