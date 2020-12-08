namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class RiotApiItemDto : IMapTo<Item>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool Consumable { get; set; }

        public byte Depth { get; set; }

        public int FullCost { get; set; }

        public int IndividualCost { get; set; }

        public int SellingCost { get; set; }

        public bool HideFromAll { get; set; }
    }
}
