namespace LoLStats.Web.ViewModels.Champions
{

    public class ChampionCounterViewModel
    {
        public string ChampionId { get; set; }

        public string CounterChampionName { get; set; }

        public string CounterChapmionKey { get; set; }

        public string ImageUrl { get; set; }

        public double WinRate { get; set; }

        public int TotalMatches { get; set; }
    }
}