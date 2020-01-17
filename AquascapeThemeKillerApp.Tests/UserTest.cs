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
    public class UserTest
    {
        private readonly IAquascapeCollectionRepository _aquascapeMemoryCollectionDal = TestFactory.CreateMemoryAquascapeCollectionDal();
        private readonly IAquascapeRepository _aquascapeMemoryDal = TestFactory.CreateMemoryAquascapeDal();
        public List<PlantModel> PlantsInAquarium { get; } = new List<PlantModel>();
        public List<FishModel> FishInAquarium { get; } = new List<FishModel>();

        [TestMethod]
        public void GetAllAquascapesTest()
        {
            var aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            var actual = aquascapeCollection.GetAllAquascapes().Count;
            const int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddAquascapeTest()
        {
            // Arrange
            PlantsInAquarium.Add(new PlantModel(1, "Echinodorus", 2));
            FishInAquarium.Add(new FishModel(1, "Tetra", 3, 1));
            var aquascapeModel = new AquascapeModel(PlantsInAquarium, FishInAquarium, 3, "The goodest aquascape1", 5);

            IAquascape testAquascape = new Aquascape(aquascapeModel);

            // Act
            var aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            aquascapeCollection.AddAquascape(aquascapeModel);

            List<IAquascape> aquascapes = aquascapeCollection.GetAllAquascapes();

            var lastAdded = aquascapes[0];

            // Assert
            Assert.AreEqual(lastAdded.AquascapeId, testAquascape.AquascapeId);
            Assert.AreEqual(lastAdded.Name, testAquascape.Name);
            Assert.AreEqual(lastAdded.Difficulty, testAquascape.Difficulty);
            Assert.AreEqual(lastAdded.PlantsInAquarium[0].PlantId, testAquascape.PlantsInAquarium[0].PlantId);
            Assert.AreEqual(lastAdded.FishInAquarium[0].FishId, testAquascape.FishInAquarium[0].FishId);
            Assert.IsTrue(aquascapes.Count == 3);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var expected = new AquascapeModel(PlantsInAquarium, FishInAquarium, 3, "The goodest aquascape1", 5);

            var aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            aquascapeCollection.AddAquascape(expected);

            var actual = _aquascapeMemoryCollectionDal.GetAquascapeById(expected.AquascapeId);

            Assert.AreEqual(expected.AquascapeId, actual.AquascapeId); 
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Difficulty, actual.Difficulty);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var aquascapeModel = new AquascapeModel(PlantsInAquarium, FishInAquarium, 3, "The aquascape1", 5);

            var aquascapeCollection = new User(_aquascapeMemoryCollectionDal);
            aquascapeCollection.AddAquascape(aquascapeModel);
            var actual = aquascapeCollection.GetAllAquascapes().Count;
            aquascapeCollection.RemoveAquascape(aquascapeModel.AquascapeId);

            Assert.AreEqual(2, actual - 1);
        }

    }
}