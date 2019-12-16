using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Logic
{
    public class AquascapeGenerator : IAquascapeGenerator
    { 
        private Plant ConvertPlant(IPlant plant)
        {
            return new Plant(plant.PlantId, plant.PlantName, plant.Difficulty);
        }

        private Fish ConvertFish(IFish fish)
        {
            return new Fish(fish.FishId, fish.FishName, fish.FishType, fish.FishSize);
        }

        public AquascapeModel GenerateAquascape()
        {
            PlantCollection plantCollection = new PlantCollection();
            FishCollection fishCollection = new FishCollection();
            var aquascape = new Aquascape();

            foreach (var plant in plantCollection.GetAllPlants())
            {
                foreach (var fish in fishCollection.GetAllFishes())
                {
                    if (aquascape.PlantsInAquarium.Count < (aquascape.PlantsInAquarium.Count + aquascape.FishInAquarium.Count * 0.75))
                    {
                        TryAddPlant(ConvertPlant(plant), aquascape);
                        break;
                    }

                    TryAddFish(ConvertFish(fish), aquascape);
                }
            }

            //foreach (var fish in aquascape._fishCollectionRepository.GetAllFishes())
            //{
            //    TryAddFish(new Fish(fish), aquascape);
            //}

            //foreach (var plant in aquascape._plantCollectionRepository.GetAllPlants())
            //{
            //    if (PlantsInAquarium.Count < (PlantsInAquarium.Count + FishInAquarium.Count * 0.75))
            //    {
            //        TryAddPlant(new Plant(plant), aquascape);
            //    }

            //}

            return new AquascapeModel(aquascape);
        }

        public bool TryAddPlant(Plant plantToFill, Aquascape aquascape)
        {
            if (aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(1)))
            {
                return false;
            }

            aquascape.PlantsInAquarium.Add(plantToFill);
            return true;
        }

        // CoupleStyle() new method to assign styles to aquascape

        // ToDo: fix Open/Closed problem caused by using strings for FishTypes
        public bool TryAddFish(Fish fishToFill, Aquascape aquascape)
        {
            //if (PlantsInAquarium.Count < (PlantsInAquarium.Count + FishInAquarium.Count * 0.75))
            //{
            //    return false;
            //}

            // FishType 2 equals Carnivore
            if (fishToFill.FishType.Equals(2))
            {
                if ((aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(1)) || aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(3))) && aquascape.FishInAquarium.Any(fish => fish.FishSize < fishToFill.FishSize))
                {
                    return false;
                }
            }
            // FishType 1 equals Herbivore
            if (fishToFill.FishType.Equals(1))
            {
                if (aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(2) && fish.FishSize > fishToFill.FishSize))
                {
                    return false;
                }
                if (aquascape.PlantsInAquarium.Count != 0)
                {
                    return false;
                }
            }
            // FishType 3 equals Normal
            if (fishToFill.FishType.Equals(3))
            {
                if (aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(2) && fish.FishSize > fishToFill.FishSize))
                {
                    return false;
                }
            }

            aquascape.FishInAquarium.Add(fishToFill);
            return true;
        }
    }
}
