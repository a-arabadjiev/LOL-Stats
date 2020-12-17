namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    public class ChampionsListViewModel
    {
        public ChampionsListViewModel()
        {
            this.Champions = new List<ChampionInListViewModel>();
        }

        public IEnumerable<ChampionInListViewModel> Champions { get; set; }
    }
}
