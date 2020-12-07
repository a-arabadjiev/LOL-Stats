namespace LoLStats.Services.Models.RiotApiDtos
{
    public class RiotApiAbilityPerLevelDto
    {
        public byte Level { get; set; }

        public double Cooldown { get; set; }

        public double Cost { get; set; }

        public bool CostsPerSecond { get; set; }

        public double Range { get; set; }
    }
}
