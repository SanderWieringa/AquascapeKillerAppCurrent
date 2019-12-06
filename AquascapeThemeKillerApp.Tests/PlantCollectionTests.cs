using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class PlantCollectionTests
    {
        private readonly IPlantCollectionRepository _plantCollectionRepository = TestFactory.CreateMemoryPlantDal();

        [TestMethod]
        public void GetAllPlantsTest_ShouldReturnTwo()
        {
            var actual = _plantCollectionRepository.GetAllPlants().Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
