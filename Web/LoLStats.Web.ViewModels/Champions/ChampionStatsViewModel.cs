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
            this.PrimaryRunesKeystoneRow = new List<RuneViewModel>();
            this.PrimaryRunesSecondRow = new List<RuneViewModel>();
            this.PrimaryRunesThirdRow = new List<RuneViewModel>();
            this.PrimaryRunesFourthRow = new List<RuneViewModel>();
            this.SecondaryRunesSecondRow = new List<RuneViewModel>();
            this.SecondaryRunesThirdRow = new List<RuneViewModel>();
            this.SecondaryRunesFourthRow = new List<RuneViewModel>();
            this.StatRunesFirstRow = new List<StatRuneViewModel>();
            this.StatRunesSecondRow = new List<StatRuneViewModel>();
            this.StatRunesThirdRow = new List<StatRuneViewModel>();
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

        public ICollection<RuneViewModel> PrimaryRunesKeystoneRow { get; set; }

        public ICollection<RuneViewModel> PrimaryRunesSecondRow { get; set; }

        public ICollection<RuneViewModel> PrimaryRunesThirdRow { get; set; }

        public ICollection<RuneViewModel> PrimaryRunesFourthRow { get; set; }

        public ICollection<RuneViewModel> SecondaryRunesSecondRow { get; set; }

        public ICollection<RuneViewModel> SecondaryRunesThirdRow { get; set; }

        public ICollection<RuneViewModel> SecondaryRunesFourthRow { get; set; }

        public ICollection<StatRuneViewModel> StatRunesFirstRow { get; set; }

        public ICollection<StatRuneViewModel> StatRunesSecondRow { get; set; }

        public ICollection<StatRuneViewModel> StatRunesThirdRow { get; set; }
    }
}
