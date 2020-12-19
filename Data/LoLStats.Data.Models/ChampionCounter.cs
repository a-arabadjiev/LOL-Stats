namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class ChampionCounter : BaseDeletableModel<int>
    {
        public virtual Champion Champion { get; set; }

        public string ChampionId { get; set; }

        public string CounterChampionName { get; set; }

        public string CounterChapmionKey { get; set; }

        public string ImageUrl { get; set; }

        public double WinRate { get; set; }

        public int TotalMatches { get; set; }
    }
}
