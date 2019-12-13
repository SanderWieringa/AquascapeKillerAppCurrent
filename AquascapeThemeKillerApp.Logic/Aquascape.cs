using AquascapeThemeKillerApp.DAL_Factory;
using AquascapeThemeKillerApp.DAL_Interfaces;
using AquascapeThemeKillerApp.Logic_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquascapeThemeKillerApp.Logic
{
    public class Aquascape : IAquascape
    {
        private readonly IAquascapeRepository _aquascapeRepository = AquascapeDALFactory.CreateAquascapeRepository();
        private readonly IPlantCollectionRepository _plantCollectionRepository = PlantDalFactory.CreatePlantCollectionRepository();
        private readonly IFishCollectionRepository _fishCollectionRepository = FishDalFactory.CreateFishCollectionRepository();

        public List<IPlant> PlantsInAquarium { get; } = new List<IPlant>();
        public List<IFish> FishInAquarium { get; } = new List<IFish>();
        public int AquascapeId { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }

        public Aquascape()
        {

        }

        public Aquascape(IAquascapeRepository aquascapeRepository)
        {
            this._aquascapeRepository = aquascapeRepository;
        }

        public Aquascape(int aquascapeId, string name, int difficulty)
        {
            AquascapeId = aquascapeId;
            Name = name;
            Difficulty = difficulty;
        }
        
        public Aquascape(AquascapeStruct aquascapeStruct) : this(aquascapeStruct.AquascapeId, aquascapeStruct.Name, aquascapeStruct.Difficulty)
        {

        }

        public Aquascape(AquascapeModel aquascapeModel) : this(aquascapeModel.AquascapeId, aquascapeModel.Name, aquascapeModel.Difficulty)
        {

        }

        public AquascapeStruct Convert(IAquascape aquascape)
        {
            return new AquascapeStruct(null, null, aquascape.AquascapeId, aquascape.Name, aquascape.Difficulty);
        }

        public void UpdateAquascape(AquascapeModel aquascapeModel)
        {
            throw new NotImplementedException();
        }

        public List<IPlant> GetAllPlantsByAquascape(int aquascapeId)
        {
            try
            {
                foreach (var plant in _aquascapeRepository.GetAllPlantsByAquascape(aquascapeId))
                {
                    PlantsInAquarium.Add(new Plant(plant));
                }

                return PlantsInAquarium;
            }
            catch (Exception e)
            {
                //logBuilder("GetAllPlantsByAquascape", "Exception", "", e.Message, "");

                return new List<IPlant>();
            }
            
        }

        public List<IFish> GetAllFishByAquascape(int aquascapeId)
        {
            try
            {
                foreach (var fish in _aquascapeRepository.GetAllFishByAquascape(aquascapeId))
                {
                    FishInAquarium.Add(new Fish(fish));
                }

                return FishInAquarium;
            }
            catch (Exception e)
            {
                return new List<IFish>();
            }
            
        }

        //private List<Plant> GetAllPlants()
        //{
        //    List<Plant> plantList = new List<Plant>();

        //    foreach (var plant in _plantCollectionRepository.GetAllPlants())
        //    {
        //        plantList.Add(new Plant(plant));
        //    }

        //    return plantList;
        //}

        //public AquascapeModel GenerateAquascape(List<PlantModel> allPlants, List<FishModel> allFishes)
        //{
        //    var aquascape = new Aquascape();

        //    foreach (var plant in allPlants)
        //    {
        //        foreach (var fish in allFishes)
        //        {
        //            if (aquascape.PlantsInAquarium.Count < (aquascape.PlantsInAquarium.Count + aquascape.FishInAquarium.Count * 0.75))
        //            {
        //                TryAddPlant(new Plant(plant), aquascape);
        //                break;
        //            }

        //            TryAddFish(new Fish(fish), aquascape);
        //        }
        //    }
            

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

        //    return new AquascapeModel(aquascape);
        //}

        //public bool TryAddPlant(Plant plantToFill, Aquascape aquascape)
        //{
        //    if (aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(1)))
        //    {
        //        return false;
        //    }

        //    aquascape.PlantsInAquarium.Add(plantToFill);
        //    return true;
        //}

        //// CoupleStyle() new method to assign styles to aquascape

        // ToDo: fix Open/Closed problem caused by using inheritance for FishTypes
        //public bool TryAddFish(Fish fishToFill, Aquascape aquascape)
        //{
        //    //if (PlantsInAquarium.Count < (PlantsInAquarium.Count + FishInAquarium.Count * 0.75))
        //    //{
        //    //    return false;
        //    //}

        //    // FishType 2 equals Carnivore
        //    if (fishToFill.FishType.Equals(2))
        //    {
        //        if ((aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(1)) || FishInAquarium.Exists(fish => fish.FishType.Equals(3))) && FishInAquarium.Any(fish => fish.FishSize < fishToFill.FishSize))
        //        {
        //            return false;
        //        }
        //    }
        //    // FishType 1 equals Herbivore
        //    if (fishToFill.FishType.Equals(1))
        //    {
        //        if (aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(2) && fish.FishSize > fishToFill.FishSize))
        //        {
        //            return false;
        //        }
        //        if (aquascape.PlantsInAquarium.Count != 0)
        //        {
        //            return false;
        //        }
        //    }
        //    // FishType 3 equals Normal
        //    if (fishToFill.FishType.Equals(3))
        //    {
        //        if (aquascape.FishInAquarium.Exists(fish => fish.FishType.Equals(2) && fish.FishSize > fishToFill.FishSize))
        //        {
        //            return false;
        //        }
        //    }

        //    aquascape.FishInAquarium.Add(fishToFill);
        //    return true;
        //}
    }
}
    