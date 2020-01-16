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
    public class PlantTests
    {
        private readonly AquascapeGenerator _generator = new AquascapeGenerator();
        private readonly Aquascape _aquascape = new Aquascape(new List<PlantModel>(), new List<FishModel>(), 0, "", 0);

        [TestMethod]
        public void TryAddPlant_PlantPlusHerbivore_ShouldReturnFalse()
        {
            var plant = new Plant(1, "Valisneria", 2);
            var herbivore = new Fish(1, "Tetra", 1, 1);

            var tryAddPlant = _generator.TryAddPlant(plant, _aquascape);
            var tryAddFish = _generator.TryAddFish(herbivore, _aquascape);


            Assert.IsTrue(tryAddPlant);
            Assert.IsFalse(tryAddFish);
        }

        [TestMethod]
        public void TryAddPlant_HerbivorePlusPlant_ShouldReturnFalse()
        {
            var herbivore = new Fish(1, "Tetra", 1, 1);
            var plant = new Plant(1, "Valisneria", 2);

            var tryAddFish = _generator.TryAddFish(herbivore, _aquascape);
            var tryAddPlant = _generator.TryAddPlant(plant, _aquascape);

            Assert.IsTrue(tryAddFish);
            Assert.IsFalse(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_NormalPlusPlant_ShouldReturnTrue()
        {
            var normal = new Fish(1, "Tetra", 3, 1);
            var plant = new Plant(1, "Valisneria", 2);

            var tryAddFish = _generator.TryAddFish(normal, _aquascape);
            var tryAddPlant = _generator.TryAddPlant(plant, _aquascape);

            Assert.IsTrue(tryAddFish);
            Assert.IsTrue(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_PlantPlusNormal_ShouldReturnTrue()
        {
            var plant = new Plant(1, "Valisneria", 2);
            var normal = new Fish(1, "Tetra", 3, 1);

            var tryAddPlant = _generator.TryAddPlant(plant, _aquascape);
            var tryAddFish = _generator.TryAddFish(normal, _aquascape);


            Assert.IsTrue(tryAddPlant);
            Assert.IsTrue(tryAddFish);
        }

        [TestMethod]
        public void TryAddPlant_CarnivorePlusPlant_ShouldReturnTrue()
        {
            var carnivore = new Fish(1, "Angelfish", 2, 1);
            var plant = new Plant(1, "Valisneria", 2);

            var tryAddFish = _generator.TryAddFish(carnivore, _aquascape);
            var tryAddPlant = _generator.TryAddPlant(plant, _aquascape);


            Assert.IsTrue(tryAddFish);
            Assert.IsTrue(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_PlantPlusCarnivore_ShouldReturnTrue()
        {
            var plant = new Plant(1, "Valisneria", 2);
            var carnivore = new Fish(1, "Angelfish", 2, 1);

            var tryAddPlant = _generator.TryAddPlant(plant, _aquascape);
            var tryAddFish = _generator.TryAddFish(carnivore, _aquascape);

            Assert.IsTrue(tryAddPlant);
            Assert.IsTrue(tryAddFish);
        }
    }
}
