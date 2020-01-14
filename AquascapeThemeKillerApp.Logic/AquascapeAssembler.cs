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

        public AquascapeModel AssemblePlants(List<IPlant> selectedPlants)
        {
            _aquascapeGenerator = new AquascapeGenerator();

            foreach (IPlant plant in selectedPlants)
            {
                if (!_aquascapeGenerator.TryAddPlant(plant as Plant, _aquascape))
                {
                    throw new ArgumentException(string.Format(PlantError, plant));
                }
            }

            return new AquascapeModel(_aquascape);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedFishes"></param>
        /// <returns></returns>
        public AquascapeModel AssembleFishes(List<IFish> selectedFishes)
        {
            _aquascapeGenerator = new AquascapeGenerator();

            foreach (IFish fish in selectedFishes)
            {
                if (!_aquascapeGenerator.TryAddFish(fish as Fish, _aquascape))
                {
                    throw new ArgumentException(string.Format(FishError, fish));
                }
            }

            return new AquascapeModel(_aquascape);
        }

        public string AssembleAquascape(List<object> list)
        {
            throw new NotImplementedException();

        }

        public AquascapeModel CreateAquascape()
        {
            return new AquascapeModel(_aquascape);
        }
    }
}
