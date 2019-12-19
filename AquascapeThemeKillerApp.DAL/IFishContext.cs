using AquascapeThemeKillerApp.DAL_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL
{
    public interface IFishContext
    {
        List<FishStruct> GetAllFishes();
        void AddFish(FishStruct fishStruct);
        void DeleteFish(int fishId);
    }
}
