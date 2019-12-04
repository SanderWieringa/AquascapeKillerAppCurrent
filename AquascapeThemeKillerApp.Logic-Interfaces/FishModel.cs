using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public class FishModel
    {
        public int FishId { get; set; }
        public string FishName { get; set; }
        public int FishType { get; set; }
        public int FishSize { get; set; }

        public FishModel(IFish fish)
        {
            FishId = fish.FishId;
            FishName = fish.FishName;
            FishType = fish.FishType;
            FishSize = fish.FishSize;
        }

        public FishModel(int fishId, string fishName, int fishType, int fishSize)
        {
            FishId = fishId;
            FishName = fishName;
            FishType = fishType;
            FishSize = fishSize;
        }
    }
}
