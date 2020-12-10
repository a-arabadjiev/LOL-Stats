namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models;
    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Mapping;

    public class RiotApiRuneDto : IMapTo<Rune>
    {
        public string Name { get; set; }

        public bool IsKeystone { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public RuneTreeType RunePath { get; set; }

        public string ImageUrl { get; set; }
    }
}
