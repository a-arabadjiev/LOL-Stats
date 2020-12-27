namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.Items;

    public class ChampionStarterItemsViewModel
    {
        public ChampionStarterItemsViewModel()
        {
            this.Items = new List<ItemViewModel>();
        }

        public ICollection<ItemViewModel> Items { get; set; }

        public string ChampionId { get; set; }

        public int PickRate { get; set; }

        public int WinRate { get; set; }
    }
}
