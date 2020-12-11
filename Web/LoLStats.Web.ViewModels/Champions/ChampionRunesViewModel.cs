namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    public class ChampionRunesViewModel
    {
        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public string MainRuneTree { get; set; }

        public string SecondaryRuneTree { get; set; }

        public string ChampionId { get; set; }

        //public ICollection<RuneViewModel> Runes { get; set; }
    }
}
