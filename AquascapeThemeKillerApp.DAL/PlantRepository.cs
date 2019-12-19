using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL
{
    public class PlantRepository : IPlantCollectionRepository
    {
        private readonly IPlantContext _context;

        public PlantRepository(IPlantContext context)
        {
            _context = context;
        }

        public void Add(PlantStruct plantStruct)
        {
            _context.AddPlant(plantStruct);
        }

        public void DeletePlant(int plantId)
        {
            _context.DeletePlant(plantId);
        }

        public List<PlantStruct> GetAllPlants()
        {
            List<PlantStruct> plantList = new List<PlantStruct>();
            foreach (var plant in _context.GetAllPlants())
            {
                plantList.Add(plant);
            }

            return plantList;
        }
    }
}
