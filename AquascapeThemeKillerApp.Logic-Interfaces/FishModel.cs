using AquascapeThemeKillerApp.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public class FishModel : IFish
    {
        public int FishId { get; set; }
        public string FishName { get; set; }
        public FishType FishType { get; set; }
        public int FishSize { get; set; }

        public FishModel(IFish fish) : this(fish.FishId, fish.FishName, fish.FishType, fish.FishSize)
        {
            
        }

        public FishModel(int fishId, string fishName, FishType fishType, int fishSize)
        {
            FishId = fishId;
            FishName = fishName;
            FishType = fishType;
            FishSize = fishSize;
        }

        public FishModel()
        {
            
        }
    }
}
