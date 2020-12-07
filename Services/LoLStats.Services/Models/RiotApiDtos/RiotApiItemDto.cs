namespace LoLStats.Services.Models.RiotApiDtos
{
    public class RiotApiItemDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RiotApiImage Image { get; set; }

        public bool Consumable { get; set; }

        public byte Depth { get; set; }

        public int FullCost { get; set; }

        public int IndividualCost { get; set; }

        public int SellingCost { get; set; }

        public bool HideFromAll { get; set; }
    }
}
