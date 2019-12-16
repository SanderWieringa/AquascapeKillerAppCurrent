using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic;
using AquascapeThemeKillerApp.Logic_Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AquascapeThemeKillerApp.Tests
{
    [TestClass]
    public class GenerateAquascapeTests
    {
        private readonly IPlantCollectionRepository _plantMemoryCollectionRepository = TestFactory.CreateMemoryPlantDal();
        private readonly IFishCollectionRepository _fishtMemoryCollectionRepository = TestFactory.CreateMemoryFishDal();
        private AquascapeGenerator _generator = new AquascapeGenerator();
        private Aquascape _aquascape = new Aquascape();
        private PlantCollection _plantCollection;
        private FishCollection _fishCollection;

        //private void InitializeFourPlantsOneNormal()
        //{
        //    _allPlants = new List<PlantModel>()
        //    {
        //        new PlantModel(1, "Echonodorus", 2),
        //        new PlantModel(2, "Echonodorus", 2),
        //        new PlantModel(3, "Echonodorus", 2),
        //        new PlantModel(4, "Echonodorus", 2)
        //    };

        //    _allFishes = new List<FishModel>()
        //    {
        //        new FishModel(1, "Tetra", 3, 5) 
        //    };
        //}

        [TestMethod]
        public void GenerateAquascape_FourPlantsPlusOneNormal_ShouldReturnFive()
        {
            _plantCollection = new PlantCollection(_plantMemoryCollectionRepository);
            _fishCollection = new FishCollection(_fishtMemoryCollectionRepository);
            _plantCollection.AddPlant(new PlantModel(1, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(2, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(3, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(4, "Echonodorus", 2));
            _fishCollection.AddFish(new FishModel(1, "Tetra", 3, 5));

            var plantsInAquascape = new List<IPlant>
            {
                new PlantModel(1, "Echonodorus", 2),
                new PlantModel(2, "Echonodorus", 2),
                new PlantModel(3, "Echonodorus", 2),
                new PlantModel(4, "Echonodorus", 2)
            };

            var fishInAquascape = new List<IFish>
            {
                new FishModel(1, "Tetra", 3, 5)
            };

            AquascapeModel actualAquascape = _generator.GenerateAquascape();
            var expectedAquascape = new AquascapeModel(plantsInAquascape, fishInAquascape, 1, "Expected Aquascape", 1);

            bool firstEqual = actualAquascape.FishInAquarium.SequenceEqual(expectedAquascape.FishInAquarium);
            bool secondEqual = actualAquascape.PlantsInAquarium.SequenceEqual(expectedAquascape.PlantsInAquarium);

            Assert.IsTrue(firstEqual);
            Assert.IsTrue(secondEqual);

            //Assert.AreEqual(expectedAquascape.FishInAquarium, actualAquascape.FishInAquarium);
            //Assert.AreEqual(expectedAquascape.PlantsInAquarium, actualAquascape.PlantsInAquarium);
        }
    }
}
