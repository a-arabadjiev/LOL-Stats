namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    public class ChampionsListViewModel
    {
        public IEnumerable<ChampionInListViewModel> Champions { get; set; }
    }
}
