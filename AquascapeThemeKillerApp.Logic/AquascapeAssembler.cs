using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.Logic
{
    public class AquascapeAssembler : IAquascapeAssembler
    {
        private readonly Aquascape _aquascape = new Aquascape();
        private AquascapeGenerator _aquascapeGenerator;

        private const string PlantError = "This plant could not be added!: {0}";
        private const string FishError = "This fish could not be added!: {0}";

        public AquascapeModel AssemblePlants(List<IPlant> selectedPlants, AquascapeModel sessionAquascapeModel)
        {
            _aquascapeGenerator = new AquascapeGenerator();

            foreach (IPlant plant in selectedPlants)
            {
                if (!_aquascapeGenerator.TryAddPlant(plant as Plant, new Aquascape(sessionAquascapeModel)))
                {
                    throw new ArgumentException(string.Format(PlantError, plant));
                }
            }

            return new AquascapeModel(_aquascape);
        }

        public AquascapeModel AssembleFishes(List<IFish> selectedFishes, AquascapeModel sessionAquascapeModel)
        {
            _aquascapeGenerator = new AquascapeGenerator();

            foreach (IFish fish in selectedFishes)
            {
                if (!_aquascapeGenerator.TryAddFish(fish as Fish, new Aquascape(sessionAquascapeModel)))
                {
                    throw new ArgumentException(string.Format(FishError, fish));
                }
            }

            return new AquascapeModel(new Aquascape(sessionAquascapeModel));
        }

        public string AssembleAquascape(List<object> list)
        {
            throw new NotImplementedException();

        }

        public AquascapeModel CreateAquascape()
        {
            return new AquascapeModel(new List<PlantModel>(), new List<FishModel>(), 0, "", 0);
        }
    }
}
