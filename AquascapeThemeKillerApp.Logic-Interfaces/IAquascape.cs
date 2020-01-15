using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IAquascape
    {
        List<PlantModel> PlantsInAquarium { get; set; }
        List<FishModel> FishInAquarium { get; set; }
        int AquascapeId { get; set; }
        string Name { get; set; }
        int Difficulty { get; set; }

        void UpdateAquascape(AquascapeModel aquascapeModel);
        //AquascapeModel GenerateAquascape(List<PlantModel> plantList, List<FishModel> fishList);
        List<PlantModel> GetAllPlantsByAquascape(int aquascapeId);
        List<FishModel> GetAllFishByAquascape(int aquascapeId);
        
    }
}
