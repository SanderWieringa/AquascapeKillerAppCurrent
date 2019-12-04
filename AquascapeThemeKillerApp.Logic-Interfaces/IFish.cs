using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic_Interfaces
{
    public interface IFish
    {
        int FishId { get; set; }
        string FishName { get; set; }
        int FishType { get; set; }
        int FishSize { get; set; }
    }
}
