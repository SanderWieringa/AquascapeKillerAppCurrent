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

        //public List<PlantModel> PlantsInAquarium { get; } = new List<PlantModel>();
        //public List<FishModel> FishInAquarium { get; } = new List<FishModel>();
        public List<PlantModel> PlantsInAquarium { get; set; }
        public List<FishModel> FishInAquarium { get; set; }
        public int AquascapeId { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }

        public Aquascape()
        {

        }

        public Aquascape(IAquascapeRepository aquascapeRepository)
        {
            _aquascapeRepository = aquascapeRepository;
        }

        public Aquascape(List<PlantModel> plantsInAquarium, List<FishModel> fishModels, int aquascapeId, string name, int difficulty)
        {
            PlantsInAquarium = plantsInAquarium;
            FishInAquarium = fishModels;
            AquascapeId = aquascapeId;
            Name = name;
            Difficulty = difficulty;
        }
        
        public Aquascape(AquascapeStruct aquascapeStruct) : this(ConvertPlantStructs(aquascapeStruct.PlantsInAquarium), ConvertFishStructs(aquascapeStruct.FishInAquarium), aquascapeStruct.AquascapeId, aquascapeStruct.Name, aquascapeStruct.Difficulty)
        {

        }

        public Aquascape(AquascapeModel aquascapeModel) : this(aquascapeModel.PlantsInAquarium, aquascapeModel.FishInAquarium, aquascapeModel.AquascapeId, aquascapeModel.Name, aquascapeModel.Difficulty)
        {

        }

        public AquascapeStruct Convert(IAquascape aquascape)
        {
            return new AquascapeStruct(ConvertPlantModels(aquascape.PlantsInAquarium), ConvertFishModels(aquascape.FishInAquarium), aquascape.AquascapeId, aquascape.Name, aquascape.Difficulty);
        }

        public void UpdateAquascape(AquascapeModel aquascapeModel)
        {
            throw new NotImplementedException();
        }

        public List<PlantModel> GetAllPlantsByAquascape(int aquascapeId)
        {
            try
            {
                PlantsInAquarium = new List<PlantModel>();

                foreach (PlantStruct plant in _aquascapeRepository.GetAllPlantsByAquascape(aquascapeId))
                {
                    PlantsInAquarium.Add(new PlantModel(new Plant(plant)));
                }

                return PlantsInAquarium;
            }
            catch (Exception e)
            {
                //logBuilder("GetAllPlantsByAquascape", "Exception", "", e.Message, "");

                return new List<PlantModel>();
            }
        }

        public List<FishModel> GetAllFishByAquascape(int aquascapeId)
        {
            try
            {
                FishInAquarium = new List<FishModel>();

                foreach (FishStruct fish in _aquascapeRepository.GetAllFishByAquascape(aquascapeId))
                {
                    FishInAquarium.Add(new FishModel(new Fish(fish)));
                }

                return FishInAquarium;
            }
            catch (Exception e)
            {
                return new List<FishModel>();
            }
            
        }

        private static List<PlantModel> ConvertPlantStructs(List<PlantStruct> plantStructs)
        {
            List<PlantModel> plantModels = new List<PlantModel>();

            foreach (PlantStruct plant in plantStructs)
            {
                plantModels.Add(new PlantModel(new Plant(plant)));
            }

            return plantModels;
        }

        private static List<FishModel> ConvertFishStructs(List<FishStruct> fishStructs)
        {
            List<FishModel> fishModels = new List<FishModel>();

            foreach (FishStruct fish in fishStructs)
            {
                fishModels.Add(new FishModel(new Fish(fish)));
            }

            return fishModels;
        }

        private static List<PlantStruct> ConvertPlantModels(List<PlantModel> plantModels)
        {
            var plantStructs = new List<PlantStruct>();

            foreach (PlantModel plant in plantModels)
            {
                PlantStruct plantStruct = new PlantStruct
                {
                    PlantId = plant.PlantId,
                    PlantName = plant.PlantName,
                    Difficulty = plant.Difficulty
                };

                plantStructs.Add(plantStruct);
            }

            return plantStructs;
        }

        private static List<FishStruct> ConvertFishModels(List<FishModel> fishModels)
        {
            var fishStructs = new List<FishStruct>();

            foreach (FishModel fish in fishModels)
            {
                FishStruct fishStruct = new FishStruct
                {
                    FishId = fish.FishId,
                    FishName = fish.FishName,
                    FishType = (int)fish.FishType,
                    FishSize = fish.FishSize
                };

                fishStructs.Add(fishStruct);
            }

            return fishStructs;
        }
    }
}
    