namespace LoLStats.Data.Models
{
    using System;
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class BaseChampionAbility : BaseDeletableModel<int>
    {
        public BaseChampionAbility()
        {
            this.PerLevelStats = new HashSet<AbilityPerLevel>();
        }

        public AbilityType AbilityType { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte MaxRank { get; set; }

        public virtual ICollection<AbilityPerLevel> PerLevelStats { get; set; }

        public int ChampionId { get; set; }

        public Champion Champion { get; set; }
    }
}
