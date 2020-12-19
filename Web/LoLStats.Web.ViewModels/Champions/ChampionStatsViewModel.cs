namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.Runes;

    public class ChampionStatsViewModel
    {
        public ChampionStatsViewModel()
        {
            this.BestAbilities = new List<ChampionAbilitiesViewModel>();
            this.BestSummonerSpells = new List<ChampionSummonerSpellsViewModel>();
            this.BestStartingItems = new List<ChampionStarterItemsViewModel>();
            this.BestItems = new List<ChampionItemsViewModel>();
            this.BestRunes = new List<ChampionRunesViewModel>();
            this.ChampionCounters = new List<ChampionCounterViewModel>();
            this.AllPrimaryRunes = new List<RuneViewModel>();
            this.AllSecondaryRunes = new List<RuneViewModel>();
            this.AllStatRunes = new List<StatRuneViewModel>();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFree { get; set; }

        public ChampionPassiveViewModel Passive { get; set; }

        public ICollection<ChampionAbilitiesViewModel> BestAbilities { get; set; }

        public ChampionRoleViewModel ChampionRole { get; set; }

        public ICollection<ChampionSummonerSpellsViewModel> BestSummonerSpells { get; set; }

        public ICollection<ChampionStarterItemsViewModel> BestStartingItems { get; set; }

        public ICollection<ChampionItemsViewModel> BestItems { get; set; }

        public ICollection<ChampionRunesViewModel> BestRunes { get; set; }

        public ICollection<ChampionCounterViewModel> ChampionCounters { get; set; }

        public ICollection<RuneViewModel> AllPrimaryRunes { get; set; }

        public ICollection<RuneViewModel> AllSecondaryRunes { get; set; }

        public ICollection<StatRuneViewModel> AllStatRunes { get; set; }
    }
}
