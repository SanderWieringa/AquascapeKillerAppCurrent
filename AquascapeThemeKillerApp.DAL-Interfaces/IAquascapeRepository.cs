using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public interface IAquascapeRepository
    {
        void UpdateAquascape(AquascapeStruct aquascapeStruct);
        List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId);
        List<FishStruct> GetAllFishByAquascape(int aquascapeId);
    }
}
