namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int FullCost { get; set; }

        public int IndividualCost { get; set; }

        public int SellingCost { get; set; }

        public bool IsPurchasable { get; set; }

        public int ChampionItemsId { get; set; }

        public virtual ChampionItems ChampionItems { get; set; }
    }
}
