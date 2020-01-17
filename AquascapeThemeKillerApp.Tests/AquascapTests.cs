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
        private readonly IAquascapeCollectionRepository _aquascapeMemoryCollectionDal = TestFactory.CreateMemoryAquascapeCollectionDal();
        private readonly IAquascapeRepository _aquascapeMemoryDal = TestFactory.CreateMemoryAquascapeDal();

        private User _aquascapeCollection;
        private Aquascape _aquascape;

        [TestMethod]
        public void GetAllPlantTest_ShouldReturnTwo()
        {
           AquascapeRepository repository = new AquascapeRepository(new AquascapeMemoryContext());
           repository.GetAllFishByAquascape(1);
        }

        [TestMethod]
        public void GetAllPlantsByAquascapeTest_ShouldReturnTwo()
        {
            _aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            _aquascape = new Aquascape(_aquascapeMemoryDal);

            var aquascapeId = _aquascapeCollection.GetAquascapeById(1).AquascapeId;
            var actual = _aquascape.GetAllPlantsByAquascape(aquascapeId).Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllFishesByAquascapeTest_ShouldReturnTwo()
        {
            _aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            _aquascape = new Aquascape(_aquascapeMemoryDal);

            var aquascapeId = _aquascapeCollection.GetAquascapeById(1).AquascapeId;
            var actual = _aquascape.GetAllFishByAquascape(aquascapeId).Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
