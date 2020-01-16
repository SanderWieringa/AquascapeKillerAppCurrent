using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic;
using AquascapeThemeKillerApp.Logic_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class FishTest
    {
        private readonly Aquascape _aquascape = new Aquascape(new List<PlantModel>(), new List<FishModel>(), 0, "", 0);
        private readonly AquascapeGenerator _generator = new AquascapeGenerator();

        [TestMethod]
        public void TryAddFish_SmallHerbivorePlusMediumCarnivore_ShouldReturnFalse()
        {
            var smallHerbivore = new Fish(1, "Tetra", 1, 1);
            var mediumCarnivore = new Fish(2, "AngelFish", 2, 3);

            var tryAddSmallHerbivore = _generator.TryAddFish(smallHerbivore, _aquascape);
            var tryAddMediumCarnivore = _generator.TryAddFish(mediumCarnivore, _aquascape);

            Assert.IsTrue(tryAddSmallHerbivore);
            Assert.IsFalse(tryAddMediumCarnivore);
        }

        [TestMethod]
        public void TryAddFish_MediumHerbivorePlusSmallCarnivore_ShouldReturnTrue()
        {
            var mediumHerbivore = new Fish(1, "Tetra", 1, 3);
            var smallCarnivore = new Fish(2, "AngelFish", 2, 1);

            var tryAddMediumHerbivore = _generator.TryAddFish(mediumHerbivore, _aquascape);
            var tryAddSmallCarnivore = _generator.TryAddFish(smallCarnivore, _aquascape);

            Assert.IsTrue(tryAddMediumHerbivore);
            Assert.IsTrue(tryAddSmallCarnivore);
        }

        [TestMethod]
        public void TryAddFish_SmallCarnivorePlusMediumHerbivore_ShouldReturnTrue()
        {
            var smallCarnivore = new Fish(1, "Angelfish", 2, 1);
            var mediumHerbivore = new Fish(2, "Tetra", 1, 3);

            var tryAddSmallCarnivore = _generator.TryAddFish(smallCarnivore, _aquascape);
            var tryAddMediumHerbivore = _generator.TryAddFish(mediumHerbivore, _aquascape);

            Assert.IsTrue(tryAddSmallCarnivore);
            Assert.IsTrue(tryAddMediumHerbivore);
        }

        [TestMethod]
        public void TryAddFish_MediumCarnivorePlusSmallHerbivore_ShouldReturnFalse()
        {
            var mediumCarnivore = new Fish(1, "Angelfish", 2, 3);
            var smallHerbivore = new Fish(2, "Tetra", 1, 1);

            var tryAddMediumCarnivore = _generator.TryAddFish(mediumCarnivore, _aquascape);
            var tryAddSmallHerbivore = _generator.TryAddFish(smallHerbivore, _aquascape);

            Assert.IsTrue(tryAddMediumCarnivore);
            Assert.IsFalse(tryAddSmallHerbivore);
        }

        [TestMethod]
        public void TryAddFish_SmallHerbivorePlusMediumNormal_ShouldReturnTrue()
        {
            var smallHerbivore = new Fish(1, "Tetra", 1, 1);
            var mediumNormal = new Fish(2, "Tetra", 3, 3);

            var tryAddSmallHerbivore = _generator.TryAddFish(smallHerbivore, _aquascape);
            var tryAddMediumNormal = _generator.TryAddFish(mediumNormal, _aquascape);

            Assert.IsTrue(tryAddSmallHerbivore);
            Assert.IsTrue(tryAddMediumNormal);
        }

        [TestMethod]
        public void TryAddFish_SmallNormalPlusMediumHerbivore_ShouldReturnTrue()
        {
            var smallNormal = new Fish(1, "Tetra", 3, 1);
            var mediumHerbivore = new Fish(2, "Tetra", 1, 3);

            var tryAddSmallNormal = _generator.TryAddFish(smallNormal, _aquascape);
            var tryAddMediumHerbivore = _generator.TryAddFish(mediumHerbivore, _aquascape);

            Assert.IsTrue(tryAddSmallNormal);
            Assert.IsTrue(tryAddMediumHerbivore);
        }

        [TestMethod]
        public void TryAddFish_SmallCarnivorePlusMediumNormal_ShouldReturnTrue()
        {
            var smallCarnivore = new Fish(1, "Tetra", 2, 1);
            var mediumNormal = new Fish(2, "AngelFish", 3, 3);

            var tryAddSmallCarnivore = _generator.TryAddFish(smallCarnivore, _aquascape);
            var tryAddMediumNormal = _generator.TryAddFish(mediumNormal, _aquascape);

            Assert.IsTrue(tryAddSmallCarnivore);
            Assert.IsTrue(tryAddMediumNormal);
        }

        [TestMethod]
        public void TryAddFish_MediumCarnivorePlusSmallNormal_ShouldReturnFalse()
        {
            var mediumCarnivore = new Fish(1, "Tetra", 2, 3);
            var smallNormal = new Fish(2, "AngelFish", 3, 1);

            var tryAddMediumCarnivore = _generator.TryAddFish(mediumCarnivore, _aquascape);
            var tryAddSmallNormal = _generator.TryAddFish(smallNormal, _aquascape);

            Assert.IsTrue(tryAddMediumCarnivore);
            Assert.IsFalse(tryAddSmallNormal);
        }

        [TestMethod]
        public void TryAddFish_MediumNormalPlusSmallCarnivore_ShouldReturnTrue()
        {
            var mediumNormal = new Fish(1, "Tetra", 3, 3);
            var smallCarnivore = new Fish(2, "AngelFish", 2, 1);

            var tryAddMediumNormal = _generator.TryAddFish(mediumNormal, _aquascape);
            var tryAddSmallCarnivore = _generator.TryAddFish(smallCarnivore, _aquascape);

            Assert.IsTrue(tryAddMediumNormal);
            Assert.IsTrue(tryAddSmallCarnivore);
        }

        [TestMethod]
        public void TryAddFish_SmallNormalPlusMediumCarnivore_ShouldReturnFalse()
        {
            var smallNormal = new Fish(1, "Tetra", 3, 1);
            var mediumCarnivore = new Fish(2, "AngelFish", 2, 3);

            var tryAddSmallNormal = _generator.TryAddFish(smallNormal, _aquascape);
            var tryAddMediumCarnivore = _generator.TryAddFish(mediumCarnivore, _aquascape);

            Assert.IsTrue(tryAddSmallNormal);
            Assert.IsFalse(tryAddMediumCarnivore);
        }
    }
}
