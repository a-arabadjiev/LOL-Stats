namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionSummonerSpells : BaseDeletableModel<int>
    {
        public ChampionSummonerSpells()
        {
            this.SummonerSpells = new HashSet<SummonerSpell>();
        }

        public decimal PickRate { get; set; }

        public decimal WinRate { get; set; }

        public virtual ICollection<SummonerSpell> SummonerSpells { get; set; }

        public int ChampionId { get; set; }

        public virtual Champion Champion { get; set; }
    }
}
