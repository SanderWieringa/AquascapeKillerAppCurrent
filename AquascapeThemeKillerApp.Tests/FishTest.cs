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
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish smallHerbivore = new Fish(1, "Tetra", 1, 1);
            Fish mediumCarnivore = new Fish(2, "AngelFish", 2, 3);

            bool tryAddSmallHerbivore = aquascape.TryAddFish(smallHerbivore, aquascape);
            bool tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);

            Assert.IsTrue(tryAddSmallHerbivore);
            Assert.IsFalse(tryAddMediumCarnivore);
        }

        [TestMethod]
        public void TryAddFish_MediumHerbivorePlusSmallCarnivore_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish mediumHerbivore = new Fish(1, "Tetra", 1, 3);
            Fish smallCarnivore = new Fish(2, "AngelFish", 2, 1);

            bool tryAddMediumHerbivore = aquascape.TryAddFish(mediumHerbivore, aquascape);
            bool tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);

            Assert.IsTrue(tryAddMediumHerbivore);
            Assert.IsTrue(tryAddSmallCarnivore);
        }

        [TestMethod]
        public void TryAddFish_SmallCarnivorePlusMediumHerbivore_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish smallCarnivore = new Fish(1, "Angelfish", 2, 1);
            Fish mediumHerbivore = new Fish(2, "Tetra", 1, 3);

            bool tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);
            bool tryAddMediumHerbivore = aquascape.TryAddFish(mediumHerbivore, aquascape);

            Assert.IsTrue(tryAddSmallCarnivore);
            Assert.IsTrue(tryAddMediumHerbivore);
        }

        [TestMethod]
        public void TryAddFish_MediumCarnivorePlusSmallHerbivore_ShouldReturnFalse()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish mediumCarnivore = new Fish(1, "Angelfish", 2, 3);
            Fish smallHerbivore = new Fish(2, "Tetra", 1, 1);

            bool tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);
            bool tryAddSmallHerbivore = aquascape.TryAddFish(smallHerbivore, aquascape);

            Assert.IsTrue(tryAddMediumCarnivore);
            Assert.IsFalse(tryAddSmallHerbivore);
        }

        [TestMethod]
        public void TryAddFish_SmallHerbivorePlusMediumNormal_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish smallHerbivore = new Fish(1, "Tetra", 1, 1);
            Fish mediumNormal = new Fish(2, "Tetra", 3, 3);

            bool tryAddSmallHerbivore = aquascape.TryAddFish(smallHerbivore, aquascape);
            bool tryAddMediumNormal = aquascape.TryAddFish(mediumNormal, aquascape);

            Assert.IsTrue(tryAddSmallHerbivore);
            Assert.IsTrue(tryAddMediumNormal);
        }

        [TestMethod]
        public void TryAddFish_SmallNormalPlusMediumHerbivore_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish smallNormal = new Fish(1, "Tetra", 3, 1);
            Fish mediumHerbivore = new Fish(2, "Tetra", 1, 3);

            bool tryAddSmallNormal = aquascape.TryAddFish(smallNormal, aquascape);
            bool tryAddMediumHerbivore = aquascape.TryAddFish(mediumHerbivore, aquascape);

            Assert.IsTrue(tryAddSmallNormal);
            Assert.IsTrue(tryAddMediumHerbivore);
        }

        [TestMethod]
        public void TryAddFish_SmallCarnivorePlusMediumNormal_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish smallCarnivore = new Fish(1, "Tetra", 2, 1);
            Fish mediumNormal = new Fish(2, "AngelFish", 3, 3);

            bool tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);
            bool tryAddMediumNormal = aquascape.TryAddFish(mediumNormal, aquascape);

            Assert.IsTrue(tryAddSmallCarnivore);
            Assert.IsTrue(tryAddMediumNormal);
        }

        [TestMethod]
        public void TryAddFish_MediumCarnivorePlusSmallNormal_ShouldReturnFalse()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish mediumCarnivore = new Fish(1, "Tetra", 2, 3);
            Fish smallNormal = new Fish(2, "AngelFish", 3, 1);

            bool tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);
            bool tryAddSmallNormal = aquascape.TryAddFish(smallNormal, aquascape);

            Assert.IsTrue(tryAddMediumCarnivore);
            Assert.IsFalse(tryAddSmallNormal);
        }

        [TestMethod]
        public void TryAddFish_MediumNormalPlusSmallCarnivore_ShouldReturnTrue()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish mediumNormal = new Fish(1, "Tetra", 3, 3);
            Fish smallCarnivore = new Fish(2, "AngelFish", 2, 1);

            bool tryAddMediumNormal = aquascape.TryAddFish(mediumNormal, aquascape);
            bool tryAddSmallCarnivore = aquascape.TryAddFish(smallCarnivore, aquascape);

            Assert.IsTrue(tryAddMediumNormal);
            Assert.IsTrue(tryAddSmallCarnivore);
        }

        [TestMethod]
        public void TryAddFish_SmallNormalPlusMediumCarnivore_ShouldReturnFalse()
        {
            Aquascape aquascape = new Aquascape(aquascapeMemoryDAL);
            Fish smallNormal = new Fish(1, "Tetra", 3, 1);
            Fish mediumCarnivore = new Fish(2, "AngelFish", 2, 3);

            bool tryAddSmallNormal = aquascape.TryAddFish(smallNormal, aquascape);
            bool tryAddMediumCarnivore = aquascape.TryAddFish(mediumCarnivore, aquascape);

            Assert.IsTrue(tryAddSmallNormal);
            Assert.IsFalse(tryAddMediumCarnivore);
        }
    }
}
