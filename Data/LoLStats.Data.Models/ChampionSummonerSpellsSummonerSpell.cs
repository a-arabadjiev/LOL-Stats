namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class ChampionSummonerSpellsSummonerSpell : BaseDeletableModel<int>
    {
        public virtual SummonerSpell SummonerSpell { get; set; }

        public int SummonerSpellId { get; set; }

        public virtual ChampionSummonerSpells ChampionSummonerSpells { get; set; }

        public int ChampionSummonerSpellsId { get; set; }
    }
}
