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
            this.PerLevel = new HashSet<AbilityPerLevel>();
        }

        public AbilityType AbilityType { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CastingResource CastingResource { get; set; }

        public virtual ICollection<AbilityPerLevel> PerLevel { get; set; }

        public int ChampionId { get; set; }

        public Champion Champion { get; set; }
    }
}
