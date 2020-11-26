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

        public decimal PickRate { get; set; }

        public decimal WinRate { get; set; }

        public int ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public ICollection<BaseChampionAbility> Abilities { get; set; }
    }
}
