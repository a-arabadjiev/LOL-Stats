namespace LoLStats.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class BaseAbility : BaseDeletableModel<string>
    {
        public BaseAbility()
        {
            this.PerLevelStats = new HashSet<AbilityPerLevel>();
            this.ChampionAbilities = new HashSet<ChampionAbilities>();
        }

        public AbilityType AbilityType { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte MaxRank { get; set; }

        public string ChampionId { get; set; }

        public Champion Champion { get; set; }

        public virtual ICollection<AbilityPerLevel> PerLevelStats { get; set; }

        public virtual ICollection<ChampionAbilities> ChampionAbilities { get; set; }
    }
}
