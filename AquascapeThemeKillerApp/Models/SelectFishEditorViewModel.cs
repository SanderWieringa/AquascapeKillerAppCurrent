using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquascapeThemeKillerApp.Models
{
    public class SelectFishEditorViewModel
    {
        public bool Selected { get; set; }
        public int FishId { get; set; }
        public string FishName { get; set; }
        public int FishType { get; set; }
        public int FishSize { get; set; }
    }
}
