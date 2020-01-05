using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IAquascape
    {
        List<IPlant> PlantsInAquarium { get; }
        List<IFish> FishInAquarium { get; }
        int AquascapeId { get; set; }
        string Name { get; set; }
        int Difficulty { get; set; }

        void UpdateAquascape(AquascapeModel aquascapeModel);
        //AquascapeModel GenerateAquascape(List<PlantModel> plantList, List<FishModel> fishList);
        List<IPlant> GetAllPlantsByAquascape(int aquascapeId);
        List<IFish> GetAllFishByAquascape(int aquascapeId);
        
    }
}
