namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class RiotApiAbilityPerLevelDto : IMapTo<AbilityPerLevel>
    {
        public byte Level { get; set; }

        public double Cooldown { get; set; }

        public double Cost { get; set; }

        public bool CostsPerSecond { get; set; }

        public double Range { get; set; }
    }
}
