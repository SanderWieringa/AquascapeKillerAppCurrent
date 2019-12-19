using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquascapeThemeKillerApp.DAL;
using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Logic
{
    public class AquascapeGenerator : IAquascapeGenerator
    {
        private readonly IPlantCollectionRepository _plantCollectionRepository = PlantDalFactory.CreatePlantCollectionRepository();
        private readonly IFishCollectionRepository _fishCollectionRepository = FishDalFactory.CreateFishCollectionRepository();

        public AquascapeGenerator()
        {
            
        }

        public AquascapeGenerator(IPlantCollectionRepository plantRepository, IFishCollectionRepository fishRepository)
        {
            _plantCollectionRepository = plantRepository;
            _fishCollectionRepository = fishRepository;
        }

        private Plant ConvertPlant(IPlant plant)
        {
            return new Plant(plant.PlantId, plant.PlantName, plant.Difficulty);
        }

        private Fish ConvertFish(IFish fish)
        {
            return new Fish(fish.FishId, fish.FishName, fish.FishType, fish.FishSize);
        }

        // CoupleStyle() new method to assign styles to aquascape
        public AquascapeModel GenerateAquascape()
        {
            var fishCollection = new FishCollection(_fishCollectionRepository);
            var plantCollection = new PlantCollection(_plantCollectionRepository);
            var aquascape = new Aquascape();
            List<IPlant> plants = plantCollection.GetAllPlants();
            List<IFish> fishes = fishCollection.GetAllFishes();

            for (var x = 0; x < plants.Count; x++)
            {
                IPlant plant = plants[x];
                for (int y = 0; y < fishes.Count; y++)
                {
                    IFish fish = fishes[y];
                    if ((aquascape.PlantsInAquarium.Count + 1) % 3 == 0 && aquascape.PlantsInAquarium.Count != 0 && !aquascape.FishInAquarium.Contains(fish))
                    {
                        TryAddFish(ConvertFish(fish), aquascape);
                        //x--;
                        break;
                    }
                }
                TryAddPlant(ConvertPlant(plant), aquascape);
            }

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
        
        public bool TryAddFish(Fish fishToFill, Aquascape aquascape)
        {
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
