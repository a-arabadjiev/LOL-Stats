namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.Runes;

    public class ChampionRunesViewModel
    {
        public ChampionRunesViewModel()
        {
            this.Runes = new List<RuneViewModel>();
            this.StatRunes = new List<StatRuneViewModel>();
        }

        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public string MainRuneTree { get; set; }

        public string SecondaryRuneTree { get; set; }

        public string ChampionId { get; set; }

        public ICollection<RuneViewModel> Runes { get; set; }

        public ICollection<StatRuneViewModel> StatRunes { get; set; }
    }
}
