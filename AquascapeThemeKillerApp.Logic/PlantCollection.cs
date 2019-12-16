using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic
{
    public class PlantCollection : IPlantCollection
    {
        private readonly IPlantCollectionRepository _plantRepository = PlantDalFactory.CreatePlantCollectionRepository();

        public PlantCollection()
        {
            
        }

        public PlantCollection(IPlantCollectionRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        public void AddPlant(PlantModel plantModel)
        {
            var plant = new Plant(plantModel);

            _plantRepository.Add(Convert(plant));
        }

        private PlantStruct Convert(IPlant plant)
        {
            return new PlantStruct(plant.PlantId, plant.PlantName, plant.Difficulty);
        }

        public List<IPlant> GetAllPlants()
        {
            List<IPlant> plantList = new List<IPlant>();

            try
            {
                foreach (var plant in _plantRepository.GetAllPlants())
                {
                    plantList.Add(new Plant(plant));
                }

                return plantList;
            }
            catch (Exception e)
            {
                return new List<IPlant>();
            }
            
        }
    }
}
