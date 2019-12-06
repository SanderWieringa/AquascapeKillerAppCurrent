using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class FishTest
    {
        private IAquascapeRepository aquascapeMemoryDAL = TestFactory.CreateMemoryAquascapeDAL();

        [TestMethod]
        public void TryAddFish_SmallHerbivorePlusMediumCarnivore_ShouldReturnFalse()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var smallHerbivore = new Fish(1, "Tetra", 1, 1);
            var mediumCarnivore = new Fish(2, "AngelFish", 2, 3);

            var tryAddSmallHerbivore = aquascape.TryAddFish(smallHerbivore, aquascape);
            var tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);

            Assert.IsTrue(tryAddSmallHerbivore);
            Assert.IsFalse(tryAddMediumCarnivore);
        }

        [TestMethod]
        public void TryAddFish_MediumHerbivorePlusSmallCarnivore_ShouldReturnTrue()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var mediumHerbivore = new Fish(1, "Tetra", 1, 3);
            var smallCarnivore = new Fish(2, "AngelFish", 2, 1);

            var tryAddMediumHerbivore = aquascape.TryAddFish(mediumHerbivore, aquascape);
            var tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);

            Assert.IsTrue(tryAddMediumHerbivore);
            Assert.IsTrue(tryAddSmallCarnivore);
        }

        [TestMethod]
        public void TryAddFish_SmallCarnivorePlusMediumHerbivore_ShouldReturnTrue()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var smallCarnivore = new Fish(1, "Angelfish", 2, 1);
            var mediumHerbivore = new Fish(2, "Tetra", 1, 3);

            var tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);
            var tryAddMediumHerbivore = aquascape.TryAddFish(mediumHerbivore, aquascape);

            Assert.IsTrue(tryAddSmallCarnivore);
            Assert.IsTrue(tryAddMediumHerbivore);
        }

        [TestMethod]
        public void TryAddFish_MediumCarnivorePlusSmallHerbivore_ShouldReturnFalse()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var mediumCarnivore = new Fish(1, "Angelfish", 2, 3);
            var smallHerbivore = new Fish(2, "Tetra", 1, 1);

            var tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);
            var tryAddSmallHerbivore = aquascape.TryAddFish(smallHerbivore, aquascape);

            Assert.IsTrue(tryAddMediumCarnivore);
            Assert.IsFalse(tryAddSmallHerbivore);
        }

        [TestMethod]
        public void TryAddFish_SmallHerbivorePlusMediumNormal_ShouldReturnTrue()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var smallHerbivore = new Fish(1, "Tetra", 1, 1);
            var mediumNormal = new Fish(2, "Tetra", 3, 3);

            var tryAddSmallHerbivore = aquascape.TryAddFish(smallHerbivore, aquascape);
            var tryAddMediumNormal = aquascape.TryAddFish(mediumNormal, aquascape);

            Assert.IsTrue(tryAddSmallHerbivore);
            Assert.IsTrue(tryAddMediumNormal);
        }

        [TestMethod]
        public void TryAddFish_SmallNormalPlusMediumHerbivore_ShouldReturnTrue()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var smallNormal = new Fish(1, "Tetra", 3, 1);
            var mediumHerbivore = new Fish(2, "Tetra", 1, 3);

            var tryAddSmallNormal = aquascape.TryAddFish(smallNormal, aquascape);
            var tryAddMediumHerbivore = aquascape.TryAddFish(mediumHerbivore, aquascape);

            Assert.IsTrue(tryAddSmallNormal);
            Assert.IsTrue(tryAddMediumHerbivore);
        }

        [TestMethod]
        public void TryAddFish_SmallCarnivorePlusMediumNormal_ShouldReturnTrue()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var smallCarnivore = new Fish(1, "Tetra", 2, 1);
            var mediumNormal = new Fish(2, "AngelFish", 3, 3);

            var tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);
            var tryAddMediumNormal = aquascape.TryAddFish(mediumNormal, aquascape);

            Assert.IsTrue(tryAddSmallCarnivore);
            Assert.IsTrue(tryAddMediumNormal);
        }

        [TestMethod]
        public void TryAddFish_MediumCarnivorePlusSmallNormal_ShouldReturnFalse()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var mediumCarnivore = new Fish(1, "Tetra", 2, 3);
            var smallNormal = new Fish(2, "AngelFish", 3, 1);

            var tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);
            var tryAddSmallNormal = aquascape.TryAddFish(smallNormal, aquascape);

            Assert.IsTrue(tryAddMediumCarnivore);
            Assert.IsFalse(tryAddSmallNormal);
        }

        [TestMethod]
        public void TryAddFish_MediumNormalPlusSmallCarnivore_ShouldReturnTrue()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var mediumNormal = new Fish(1, "Tetra", 3, 3);
            var smallCarnivore = new Fish(2, "AngelFish", 2, 1);

            var tryAddMediumNormal = aquascape.TryAddFish(mediumNormal, aquascape);
            var tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);

            Assert.IsTrue(tryAddMediumNormal);
            Assert.IsTrue(tryAddSmallCarnivore);
        }

        [TestMethod]
        public void TryAddFish_SmallNormalPlusMediumCarnivore_ShouldReturnFalse()
        {
            var aquascape = new Aquascape(aquascapeMemoryDAL);
            var smallNormal = new Fish(1, "Tetra", 3, 1);
            var mediumCarnivore = new Fish(2, "AngelFish", 2, 3);

            var tryAddSmallNormal = aquascape.TryAddFish(smallNormal, aquascape);
            var tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);

            Assert.IsTrue(tryAddSmallNormal);
            Assert.IsFalse(tryAddMediumCarnivore);
        }
    }
}
