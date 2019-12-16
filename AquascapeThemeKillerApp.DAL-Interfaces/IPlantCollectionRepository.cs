using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public interface IPlantCollectionRepository
    {
        List<PlantStruct> GetAllPlants();
        void Add(PlantStruct plantStruct);
    }
}
