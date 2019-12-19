using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class PlantTests
    {
        AquascapeGenerator generator = new AquascapeGenerator();

        [TestMethod]
        public void TryAddPlant_PlantPlusHerbivore_ShouldReturnFalse()
        {
            var aquascape = new Aquascape();
            var plant = new Plant(1, "Valisneria", 2);
            var herbivore = new Fish(1, "Tetra", 1, 1);

            var tryAddPlant = generator.TryAddPlant(plant, aquascape);
            var tryAddFish = generator.TryAddFish(herbivore, aquascape);


            Assert.IsTrue(tryAddPlant);
            Assert.IsFalse(tryAddFish);
        }

        [TestMethod]
        public void TryAddPlant_HerbivorePlusPlant_ShouldReturnFalse()
        {
            var aquascape = new Aquascape();
            var herbivore = new Fish(1, "Tetra", 1, 1);
            var plant = new Plant(1, "Valisneria", 2);

            var tryAddFish = generator.TryAddFish(herbivore, aquascape);
            var tryAddPlant = generator.TryAddPlant(plant, aquascape);

            Assert.IsTrue(tryAddFish);
            Assert.IsFalse(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_NormalPlusPlant_ShouldReturnTrue()
        {
            var aquascape = new Aquascape();
            var normal = new Fish(1, "Tetra", 3, 1);
            var plant = new Plant(1, "Valisneria", 2);

            var tryAddFish = generator.TryAddFish(normal, aquascape);
            var tryAddPlant = generator.TryAddPlant(plant, aquascape);

            Assert.IsTrue(tryAddFish);
            Assert.IsTrue(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_PlantPlusNormal_ShouldReturnTrue()
        {
            var aquascape = new Aquascape();
            var plant = new Plant(1, "Valisneria", 2);
            var normal = new Fish(1, "Tetra", 3, 1);

            var tryAddPlant = generator.TryAddPlant(plant, aquascape);
            var tryAddFish = generator.TryAddFish(normal, aquascape);


            Assert.IsTrue(tryAddPlant);
            Assert.IsTrue(tryAddFish);
        }

        [TestMethod]
        public void TryAddPlant_CarnivorePlusPlant_ShouldReturnTrue()
        {
            var aquascape = new Aquascape();
            var carnivore = new Fish(1, "Angelfish", 2, 1);
            var plant = new Plant(1, "Valisneria", 2);

            var tryAddFish = generator.TryAddFish(carnivore, aquascape);
            var tryAddPlant = generator.TryAddPlant(plant, aquascape);


            Assert.IsTrue(tryAddFish);
            Assert.IsTrue(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_PlantPlusCarnivore_ShouldReturnTrue()
        {
            var aquascape = new Aquascape();
            var plant = new Plant(1, "Valisneria", 2);
            var carnivore = new Fish(1, "Angelfish", 2, 1);

            var tryAddPlant = generator.TryAddPlant(plant, aquascape);
            var tryAddFish = generator.TryAddFish(carnivore, aquascape);

            Assert.IsTrue(tryAddPlant);
            Assert.IsTrue(tryAddFish);
        }
    }
}
