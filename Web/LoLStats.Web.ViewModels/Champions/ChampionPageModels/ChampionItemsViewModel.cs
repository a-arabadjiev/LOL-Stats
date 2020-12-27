namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.Items;

    public class ChampionItemsViewModel
    {
        public ChampionItemsViewModel()
        {
            this.Items = new List<ItemViewModel>();
        }

        public virtual ICollection<ItemViewModel> Items { get; set; }

        public string ChampionId { get; set; }

        public int WinRate { get; set; }
    }
}
