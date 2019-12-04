using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL
{
    public interface IAquascapeContext
    {
        void UpdateAquascape(AquascapeStruct aquascapeStruct);
        void RemoveAquascape(int aquascapeId);
        void AddAquascape(AquascapeStruct aquascapeStruct);
        List<AquascapeStruct> GetAllAquascapes();
        AquascapeStruct GetAquascapeById(int aquascapeId);
        AquascapeStruct GetAquascapeByStyle();
        List<PlantStruct> GetAllPlantsByAquascape(int aquascapeId);
        List<FishStruct> GetAllFishByAquascape(int aquascapeId);
    }
}
