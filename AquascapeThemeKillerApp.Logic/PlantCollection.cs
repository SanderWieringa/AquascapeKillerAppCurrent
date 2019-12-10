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
