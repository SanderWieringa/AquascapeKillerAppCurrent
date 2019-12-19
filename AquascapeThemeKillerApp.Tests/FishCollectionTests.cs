using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class FishCollectionTests
    {
        private readonly IFishCollectionRepository _fishMemoryCollectionDal = TestFactory.CreateMemoryFishDal();

        [TestMethod]
        public void GetAllFishesTest()
        {
            _fishMemoryCollectionDal.AddFish(new FishStruct(1, "Tetra", 3, 3));
            _fishMemoryCollectionDal.AddFish(new FishStruct(2, "Angel Fish", 2, 3));
            var actual = _fishMemoryCollectionDal.GetAllFishes().Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }

    }
}
