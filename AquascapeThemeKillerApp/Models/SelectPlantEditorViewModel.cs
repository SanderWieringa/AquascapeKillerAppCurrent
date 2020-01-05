using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquascapeThemeKillerApp.Models
{
    public class SelectPlantEditorViewModel
    {
        public bool Selected { get; set; }
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int Difficulty { get; set; }

    }
}
