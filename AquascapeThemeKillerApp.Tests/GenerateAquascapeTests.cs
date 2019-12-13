using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.Logic;
using AquascapeThemeKillerApp.Logic_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class GenerateAquascapeTests
    {
        private Manager manager = new Manager();
        private Aquascape _aquascape = new Aquascape();
        private List<Fish> _allFishes;
        private List<Plant> _allPlants;

        private void InitializeFourPlantsOneNormal()
        {
            _allPlants = new List<Plant>()
            {
                new Plant(1, "Echonodorus", 2),
                new Plant(2, "Echonodorus", 2),
                new Plant(3, "Echonodorus", 2),
                new Plant(4, "Echonodorus", 2)
            };

            _allFishes = new List<Fish>()
            {
                new Fish(1, "Tetra", 3, 5)
            };
        }

        [TestMethod]
        public void GenerateAquascape_FourPlantsPlusOneNormal_ShouldReturnFive()
        {
            InitializeFourPlantsOneNormal();

            manager.GenerateAquascape();

        }
    }
}
