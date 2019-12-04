using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public interface IAquascapeCollectionRepository
    {
        void AddAquascape(AquascapeStruct aquascapeStruct);
        void RemoveAquascape(int aquascapeId);
        List<AquascapeStruct> GetAllAquascapes();
        AquascapeStruct GetAquascapeById(int aquascapeId);
        AquascapeStruct GetAquascapeByStyle();
    }
}
