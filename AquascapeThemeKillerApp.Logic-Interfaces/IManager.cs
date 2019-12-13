using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IManager
    {
        AquascapeModel GenerateAquascape(List<PlantModel> allPlants, List<FishModel> allFishModels);
    }
}
