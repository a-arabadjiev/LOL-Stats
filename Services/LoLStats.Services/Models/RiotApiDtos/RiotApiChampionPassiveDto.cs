namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class RiotApiChampionPassiveDto : IMapTo<ChampionPassive>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
