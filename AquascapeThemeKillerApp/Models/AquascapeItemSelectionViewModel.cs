using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquascapeThemeKillerApp.Models
{
    public class AquascapeItemSelectionViewModel
    {
        public List<SelectPlantEditorViewModel> Plants { get; set; }
        public List<SelectFishEditorViewModel> Fishes { get; set; }

        public AquascapeItemSelectionViewModel()
        {
            Plants = new List<SelectPlantEditorViewModel>();
            Fishes = new List<SelectFishEditorViewModel>();
        }

        public IEnumerable<int> GetSelectedPlantIds()
        {
            return (from plant in Plants where plant.Selected select plant.PlantId);
        }

        public List<int> GetSelectedFishIds()
        {
            return (from fish in Fishes where fish.Selected select fish.FishId).ToList();
        }
    }
}
