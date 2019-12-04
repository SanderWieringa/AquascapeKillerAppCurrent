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
        private IAquascapeRepository aquascapeMemoryDAL = TestFactory.CreateMemoryAquascapeDAL();


        [TestMethod]
        public void TryAddPlant_PlantPlusHerbivore_ShouldReturnFalse()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Plant plant = new Plant(1, "Valisneria", 2);
            Fish herbivore = new Fish(1, "Tetra", 1, 1);

            bool tryAddPlant = aquascape.TryAddPlant(plant);
            bool tryAddFish = aquascape.TryAddFish(herbivore);
            

            Assert.IsTrue(tryAddPlant);
            Assert.IsFalse(tryAddFish);
        }

        [TestMethod]
        public void TryAddPlant_HerbivorePlusPlant_ShouldReturnFalse()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish herbivore = new Fish(1, "Tetra", 1, 1);
            Plant plant = new Plant(1, "Valisneria", 2);

            bool tryAddFish = aquascape.TryAddFish(herbivore);
            bool tryAddPlant = aquascape.TryAddPlant(plant);

            Assert.IsTrue(tryAddFish);
            Assert.IsFalse(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_NormalPlusPlant_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish normal = new Fish(1, "Tetra", 3, 1);
            Plant plant = new Plant(1, "Valisneria", 2);

            bool tryAddFish = aquascape.TryAddFish(normal);
            bool tryAddPlant = aquascape.TryAddPlant(plant);

            Assert.IsTrue(tryAddFish);
            Assert.IsTrue(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_PlantPlusNormal_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Plant plant = new Plant(1, "Valisneria", 2);
            Fish normal = new Fish(1, "Tetra", 3, 1);

            bool tryAddPlant = aquascape.TryAddPlant(plant);
            bool tryAddFish = aquascape.TryAddFish(normal);
            

            Assert.IsTrue(tryAddPlant);
            Assert.IsTrue(tryAddFish);
        }

        [TestMethod]
        public void TryAddPlant_CarnivorePlusPlant_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish carnivore = new Fish(1, "Angelfish", 2, 1);
            Plant plant = new Plant(1, "Valisneria", 2);

            bool tryAddFish = aquascape.TryAddFish(carnivore);
            bool tryAddPlant = aquascape.TryAddPlant(plant);


            Assert.IsTrue(tryAddFish);
            Assert.IsTrue(tryAddPlant);
        }

        [TestMethod]
        public void TryAddPlant_PlantPlusCarnivore_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Plant plant = new Plant(1, "Valisneria", 2);
            Fish carnivore = new Fish(1, "Angelfish", 2, 1);

            bool tryAddPlant = aquascape.TryAddPlant(plant);
            bool tryAddFish = aquascape.TryAddFish(carnivore);

            Assert.IsTrue(tryAddPlant);
            Assert.IsTrue(tryAddFish);
        }
    }
}
