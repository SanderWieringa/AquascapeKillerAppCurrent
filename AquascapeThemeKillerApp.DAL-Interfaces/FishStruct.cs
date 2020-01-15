using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public struct FishStruct
    {
        public int FishId { get; set; }
        public string FishName { get; set; }
        public int FishType { get; set; }
        public int FishSize { get; set; }


        public FishStruct(int fishId, string fishName, int fishType, int fishSize)
        {
            FishId = fishId;
            FishName = fishName;
            FishType = fishType;
            FishSize = fishSize;
        }
    }
}
