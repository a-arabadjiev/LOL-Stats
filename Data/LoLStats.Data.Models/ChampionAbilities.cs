namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionAbilities : BaseDeletableModel<int>
    {
        public ChampionAbilities()
        {
            this.Abilities = new HashSet<BaseChampionAbility>();
        }

        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public virtual ICollection<BaseChampionAbility> Abilities { get; set; }
    }
}
