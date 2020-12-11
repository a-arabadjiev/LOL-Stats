namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    public class ChampionStatsViewModel
    {
        public ChampionStatsViewModel()
        {
            this.CounterChampions = new HashSet<string>();
        }

        public string Name { get; set; }

        public ChampionRunesViewModel RunesInfo { get; set; }

        public ICollection<string> CounterChampions { get; set; }
    }
}
