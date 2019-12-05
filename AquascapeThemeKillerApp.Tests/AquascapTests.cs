using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class AquascapTests
    {
        private IAquascapeRepository aquascapeMemoryDAL = TestFactory.CreateMemoryAquascapeDAL();

        [TestMethod]
        public void GetAllPlantsByAquascapeTest_ShouldReturnTwo()
        {
            User user = new User();
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);

            int aquascapeId = user.GetAquascapeById(1).AquascapeId;
            int actual = aquascape.GetAllPlantsByAquascape(aquascapeId).Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllFishesByAquascapeTest_ShouldReturnTwo()
        {
            User user = new User();
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);

            int aquascapeId = user.GetAquascapeById(1).AquascapeId;
            int actual = aquascape.GetAllFishByAquascape(aquascapeId).Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
