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
            _plantCollectionRepository.Add(new PlantStruct(1, "Echinodorus Ozelot", 2));
            _plantCollectionRepository.Add(new PlantStruct(2, "Red Tiger Lotus", 3));
            var actual = _plantCollectionRepository.GetAllPlants().Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }
    }
}
