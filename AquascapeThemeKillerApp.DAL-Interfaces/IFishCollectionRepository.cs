using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public interface IFishCollectionRepository
    {
        List<FishStruct> GetAllFishes();
        void AddFish(FishStruct fishStruct);
    }
}
