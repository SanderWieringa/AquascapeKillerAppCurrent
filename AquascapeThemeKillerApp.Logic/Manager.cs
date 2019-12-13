using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;

namespace AquascapeThemeKillerApp.Logic
{
    public class Manager : IManager
    {
        private readonly IPlantCollectionRepository _plantCollectionRepository = PlantDalFactory.CreatePlantCollectionRepository();
        private readonly IFishCollectionRepository _fishCollectionRepository = FishDalFactory.CreateFishCollectionRepository();

        private List<PlantModel> _allPlants;
        private List<FishModel> _allFishes;

        private List<PlantModel> GetAllPlants()
        {
            try
            {
                _allPlants = new List<PlantModel>();

                foreach (var plant in _plantCollectionRepository.GetAllPlants())
                {
                    _allPlants.Add(convertToPlantModel(plant));
                }

                return _allPlants;
            }
            catch (Exception e)
            {
                return new List<PlantModel>();
            }
            
        }

        private List<FishModel> GetAllFishes()
        {
            try
            {
                _allFishes = new List<FishModel>();

                foreach (var fish in _fishCollectionRepository.GetAllFishes())
                {
                    _allFishes.Add(ConvertToFishModel(fish));
                }

                return _allFishes;
            }
            catch (Exception e)
            {
                return new List<FishModel>();
            }
        }

        private PlantModel convertToPlantModel(PlantStruct plantStruct)
        {
            return new PlantModel(plantStruct.PlantId, plantStruct.PlantName, plantStruct.Difficulty);
        }

        private FishModel ConvertToFishModel(FishStruct fishStruct)
        {
            return new FishModel(fishStruct.FishId, fishStruct.FishName, fishStruct.FishType, fishStruct.FishSize);
        }

        public AquascapeModel GenerateAquascape(List<PlantModel> allPlants, List<FishModel> allFishes)
        {
            var aquascape = new Aquascape();

            foreach (var plant in allPlants)
            {
                foreach (var fish in allFishes)
                {
                    if (aquascape.PlantsInAquarium.Count < (aquascape.PlantsInAquarium.Count + aquascape.FishInAquarium.Count * 0.75))
                    {
                        TryAddPlant(new Plant(plant), aquascape);
                        break;
                    }

                    TryAddFish(new Fish(fish), aquascape);
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
