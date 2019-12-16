using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IPlantCollection
    {
        List<IPlant> GetAllPlants();
        void AddPlant(PlantModel plantModel);
    }
}
