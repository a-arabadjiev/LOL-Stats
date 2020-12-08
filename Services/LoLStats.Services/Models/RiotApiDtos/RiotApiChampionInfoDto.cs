namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class RiotApiChampionInfoDto : IMapTo<ChampionInfo>
    {
        public byte Attack { get; set; }

        public byte Defense { get; set; }

        public byte Difficulty { get; set; }

        public byte Magic { get; set; }
    }
}
