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

        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public string SummonerSpellPriority { get; set; }

        public virtual ICollection<SummonerSpell> SummonerSpells { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }
    }
}
