using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IFishCollection
    {
        List<IFish> GetAllFishes();
        void AddFish(FishModel fishModel);
    }
}
