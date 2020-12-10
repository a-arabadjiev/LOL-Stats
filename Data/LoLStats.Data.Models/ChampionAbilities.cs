namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionAbilities : BaseDeletableModel<int>
    {
        public ChampionAbilities()
        {
            this.Abilities = new HashSet<BaseAbility>();
        }

        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public virtual ICollection<BaseAbility> Abilities { get; set; }
    }
}
