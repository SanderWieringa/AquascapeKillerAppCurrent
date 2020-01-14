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

        public List<PlantModel> PlantsInAquarium { get; } = new List<PlantModel>();
        public List<FishModel> FishInAquarium { get; } = new List<FishModel>();
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

        public List<PlantModel> GetAllPlantsByAquascape(int aquascapeId)
        {
            try
            {
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
    }
}
    