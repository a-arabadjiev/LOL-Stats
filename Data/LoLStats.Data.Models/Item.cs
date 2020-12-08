namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class Item : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int FullCost { get; set; }

        public int IndividualCost { get; set; }

        public int SellingCost { get; set; }

        public bool IsPurchasable { get; set; }
    }
}
