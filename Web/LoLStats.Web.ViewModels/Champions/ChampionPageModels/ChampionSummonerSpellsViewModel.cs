namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.SummonerSpells;

    public class ChampionSummonerSpellsViewModel
    {
        public ChampionSummonerSpellsViewModel()
        {
            this.SummonerSpells = new List<SummonerSpellViewModel>();
        }

        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public ICollection<SummonerSpellViewModel> SummonerSpells { get; set; }
    }
}
