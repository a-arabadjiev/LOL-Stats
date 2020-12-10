namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public Item()
        {
            this.ChampionStarterItems = new HashSet<ChampionStarterItems>();
            this.ChampionItems = new HashSet<ChampionItems>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int FullCost { get; set; }

        public int IndividualCost { get; set; }

        public int SellingCost { get; set; }

        public bool IsPurchasable { get; set; }

        public virtual ICollection<ChampionStarterItems> ChampionStarterItems { get; set; }

        public virtual ICollection<ChampionItems> ChampionItems { get; set; }
    }
}
