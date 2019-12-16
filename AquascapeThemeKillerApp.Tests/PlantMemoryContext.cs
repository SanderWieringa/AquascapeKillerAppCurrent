using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.Tests
{
    public class PlantMemoryContext : IPlantContext
    {
        private readonly List<PlantStruct> _plantStructs = new List<PlantStruct>();

        private void PrefillPlantList()
        {
            _plantStructs.Add(new PlantStruct(1, "Echinodorus Ozelot", 2));
            _plantStructs.Add(new PlantStruct(2, "Red Tiger Lotus", 3));
        }

        public List<PlantStruct> GetAllPlants()
        {
            PrefillPlantList();
            return _plantStructs;
        }

        public void AddPlant(PlantStruct plantStruct)
        {
            _plantStructs.Add(plantStruct);
        }
    }
}
