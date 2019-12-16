using System;
using System.Collections.Generic;
using System.Text;
using AquascapeThemeKillerApp.DAL_Interfaces;

namespace AquascapeThemeKillerApp.DAL
{
    public interface IPlantContext
    {
        List<PlantStruct> GetAllPlants();
        void AddPlant(PlantStruct plantStruct);
    }
}
