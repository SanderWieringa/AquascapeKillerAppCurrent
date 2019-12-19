using System.Collections.Generic;
using System.Linq;
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
        
        private PlantCollection _plantCollection;
        private FishCollection _fishCollection;

        [TestMethod]
        public void GenerateAquascape_ThreePlantsPlusOneNormal_ShouldReturnTrue()
        {
            var generator = new AquascapeGenerator(_plantMemoryCollectionRepository, _fishtMemoryCollectionRepository);
            _plantCollection = new PlantCollection(_plantMemoryCollectionRepository);
            _fishCollection = new FishCollection(_fishtMemoryCollectionRepository);
            _plantCollection.AddPlant(new PlantModel(1, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(2, "Echonodorus", 2)); 
            _plantCollection.AddPlant(new PlantModel(3, "Echonodorus", 2));
            _fishCollection.AddFish(new FishModel(1, "Tetra", 3, 5));

            var plantsInAquascape = new List<IPlant>
            {
                new PlantModel(1, "Echonodorus", 2),
                new PlantModel(2, "Echonodorus", 2),
                new PlantModel(3, "Echonodorus", 2)
            };
            var fishInAquascape = new List<IFish>
            {
                new FishModel(1, "Tetra", 3, 5)
            };

            AquascapeModel actualAquascape = generator.GenerateAquascape();
            var expectedAquascape = new AquascapeModel(plantsInAquascape, fishInAquascape, 1, "Expected Aquascape", 1);

            Assert.AreEqual(3, actualAquascape.PlantsInAquarium.Count);
            Assert.AreEqual(1, actualAquascape.FishInAquarium.Count);
        }

        [TestMethod]
        public void GenerateAquascape_SixPlantsPlusTwoNormal_ShouldReturnTrue()
        {
            var generator = new AquascapeGenerator(_plantMemoryCollectionRepository, _fishtMemoryCollectionRepository);
            _plantCollection = new PlantCollection(_plantMemoryCollectionRepository);
            _fishCollection = new FishCollection(_fishtMemoryCollectionRepository);
            _plantCollection.AddPlant(new PlantModel(1, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(2, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(3, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(4, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(5, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(6, "Echonodorus", 2));
            _fishCollection.AddFish(new FishModel(1, "Tetra", 3, 5));
            _fishCollection.AddFish(new FishModel(2, "Tetra", 3, 5));

            var plantsInAquascape = new List<IPlant>
            {
                new PlantModel(1, "Echonodorus", 2),
                new PlantModel(2, "Echonodorus", 2),
                new PlantModel(3, "Echonodorus", 2),
                new PlantModel(4, "Echonodorus", 2),
                new PlantModel(5, "Echonodorus", 2),
                new PlantModel(6, "Echonodorus", 2)
            };
            var fishInAquascape = new List<IFish>
            {
                new FishModel(1, "Tetra", 3, 5),
                new FishModel(2, "Tetra", 3, 5)
            };

            AquascapeModel actualAquascape = generator.GenerateAquascape();
            var expectedAquascape = new AquascapeModel(plantsInAquascape, fishInAquascape, 1, "Expected Aquascape", 1);

            Assert.AreEqual(2, actualAquascape.FishInAquarium.Count);
            Assert.AreEqual(6, actualAquascape.PlantsInAquarium.Count);
        }

        [TestMethod]
        public void GenerateAquascape_NinePlantsPlusThreeNormal_ShouldReturnTrue()
        {
            var generator = new AquascapeGenerator(_plantMemoryCollectionRepository, _fishtMemoryCollectionRepository);
            _plantCollection = new PlantCollection(_plantMemoryCollectionRepository);
            _fishCollection = new FishCollection(_fishtMemoryCollectionRepository);
            _plantCollection.AddPlant(new PlantModel(1, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(2, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(3, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(4, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(5, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(6, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(7, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(8, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(9, "Echonodorus", 2));
            _fishCollection.AddFish(new FishModel(1, "Tetra", 3, 5));
            _fishCollection.AddFish(new FishModel(2, "Tetra", 3, 5));
            _fishCollection.AddFish(new FishModel(3, "Tetra", 3, 5));

            var plantsInAquascape = new List<IPlant>
            {
                new PlantModel(1, "Echonodorus", 2),
                new PlantModel(2, "Echonodorus", 2),
                new PlantModel(3, "Echonodorus", 2),
                new PlantModel(4, "Echonodorus", 2),
                new PlantModel(5, "Echonodorus", 2),
                new PlantModel(6, "Echonodorus", 2),
                new PlantModel(7, "Echonodorus", 2),
                new PlantModel(8, "Echonodorus", 2),
                new PlantModel(9, "Echonodorus", 2)
            };
            var fishInAquascape = new List<IFish>
            {
                new FishModel(1, "Tetra", 3, 5),
                new FishModel(2, "Tetra", 3, 5),
                new FishModel(3, "Tetra", 3, 5)
            };

            AquascapeModel actualAquascape = generator.GenerateAquascape();
            var expectedAquascape = new AquascapeModel(plantsInAquascape, fishInAquascape, 1, "Expected Aquascape", 1);

            Assert.AreEqual(3, actualAquascape.FishInAquarium.Count);
            Assert.AreEqual(9, actualAquascape.PlantsInAquarium.Count);
        }

        [TestMethod]
        public void GenerateAquascape_FivePlantsPlusOneNormal_ShouldReturnTrue()
        {
            var generator = new AquascapeGenerator(_plantMemoryCollectionRepository, _fishtMemoryCollectionRepository);
            _plantCollection = new PlantCollection(_plantMemoryCollectionRepository);
            _fishCollection = new FishCollection(_fishtMemoryCollectionRepository);
            _plantCollection.AddPlant(new PlantModel(1, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(2, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(3, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(4, "Echonodorus", 2));
            _plantCollection.AddPlant(new PlantModel(5, "Echonodorus", 2));
            _fishCollection.AddFish(new FishModel(1, "Tetra", 3, 5));
            _fishCollection.AddFish(new FishModel(2, "Tetra", 3, 5));

            var plantsInAquascape = new List<IPlant>
            {
                new PlantModel(1, "Echonodorus", 2),
                new PlantModel(2, "Echonodorus", 2),
                new PlantModel(3, "Echonodorus", 2),
                new PlantModel(4, "Echonodorus", 2),
                new PlantModel(5, "Echonodorus", 2)
            };
            var fishInAquascape = new List<IFish>
            {
                new FishModel(1, "Tetra", 3, 5)
            };

            AquascapeModel actualAquascape = generator.GenerateAquascape();
            var expectedAquascape = new AquascapeModel(plantsInAquascape, fishInAquascape, 1, "Expected Aquascape", 1);

            Assert.AreEqual(5, actualAquascape.PlantsInAquarium.Count);
            Assert.AreEqual(1, actualAquascape.FishInAquarium.Count);
        }
    }
}
