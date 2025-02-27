﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AquascapeThemeKillerApp.DAL_Interfaces
{
    public struct AquascapeStruct
    {
        public List<FishStruct> FishInAquarium { get; private set; }
        public List<PlantStruct> PlantsInAquarium { get; private set; }
        public int AquascapeId { get; private set; }
        public string Name { get; private set; }
        public int Difficulty { get; private set; }

        public AquascapeStruct(List<FishStruct> fishInAquarium, List<PlantStruct> plantsInAquarium, int aquascapeId, string name, int difficulty)
        {
            FishInAquarium = fishInAquarium;
            PlantsInAquarium = plantsInAquarium;
            AquascapeId = aquascapeId;
            Name = name;
            Difficulty = difficulty;
        }


    }
}
