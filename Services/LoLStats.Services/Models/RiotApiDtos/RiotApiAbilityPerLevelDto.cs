namespace LoLStats.Services.Models.RiotApiDtos
{
    public class RiotApiAbilityPerLevelDto
    {
        public int Level { get; set; }

        public int Cooldown { get; set; }

        public int Cost { get; set; }

        public bool CostsPerSecond { get; set; }

        public int Range { get; set; }
    }
}
