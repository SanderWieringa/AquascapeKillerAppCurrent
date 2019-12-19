using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class AquascapTests
    {
        private readonly IAquascapeCollectionRepository _aquascapeMemoryCollectionDal = TestFactory.CreateMemoryAquascapeCollectionDAL();
        private readonly IAquascapeRepository _aquascapeMemoryDal = TestFactory.CreateMemoryAquascapeDAL();

        [TestMethod]
        public void GetAllPlantTest_ShouldReturnTwo()
        {
           AquascapeRepository repository = new AquascapeRepository(new AquascapeMemoryContext());
           repository.GetAllFishByAquascape(1);
        }

        [TestMethod]
        public void GetAllPlantsByAquascapeTest_ShouldReturnTwo()
        {
            var aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            var aquascape = new Aquascape(_aquascapeMemoryDal);

            var aquascapeId = aquascapeCollection.GetAquascapeById(1).AquascapeId;
            var actual = aquascape.GetAllPlantsByAquascape(aquascapeId).Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllFishesByAquascapeTest_ShouldReturnTwo()
        {
            var aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            var aquascape = new Aquascape(_aquascapeMemoryDal);

            var aquascapeId = aquascapeCollection.GetAquascapeById(1).AquascapeId;
            var actual = aquascape.GetAllFishByAquascape(aquascapeId).Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
