namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class SummonerSpell : BaseDeletableModel<int>
    {
        public SummonerSpell()
        {
            this.ChampionSummonerSpells = new HashSet<ChampionSummonerSpells>();
        }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Tooltip { get; set; }

        public string Description { get; set; }

        public double BaseCooldown { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<ChampionSummonerSpells> ChampionSummonerSpells { get; set; }
    }
}
