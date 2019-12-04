using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public struct FishStruct
    {
        public int FishId { get; private set; }
        public string FishName { get; private set; }
        public int FishType { get; private set; }
        public int FishSize { get; private set; }


        public FishStruct(int fishId, string fishName, int fishType, int fishSize)
        {
            FishId = fishId;
            FishName = fishName;
            FishType = fishType;
            FishSize = fishSize;
        }
    }
}
