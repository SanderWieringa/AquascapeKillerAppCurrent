using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.Tests
{
    public class PlantMemoryContext : IPlantContext
    {
        private readonly List<PlantStruct> _plantStructs = new List<PlantStruct>();

        public List<PlantStruct> GetAllPlants()
        {
            return _plantStructs;
        }

        public void AddPlant(PlantStruct plantStruct)
        {
            _plantStructs.Add(plantStruct);
        }

        public void DeletePlant(int plantId)
        {
            foreach (var plant in _plantStructs.Where(plant => plant.PlantId == plantId).ToArray()) _plantStructs.Remove(plant);
        }
    }
}
