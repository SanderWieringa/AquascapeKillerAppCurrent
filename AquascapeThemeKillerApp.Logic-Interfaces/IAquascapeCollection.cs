using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IAquascapeCollection
    {
        void RemoveAquascape(int aquascapeId);
        void AddAquascape(AquascapeModel aquascapeModel);
        List<IAquascape> GetAllAquascapes();
        AquascapeModel GetAquascapeById(int aquascapeId);
        AquascapeModel GetAquascapeByStyle();
    }
}
