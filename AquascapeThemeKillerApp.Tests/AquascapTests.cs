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
        public void GetAllPlantsTest()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            int actual = aquascape.GetAllPlantsByAquascape(1).Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
