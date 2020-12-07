namespace LoLStats.Services.Models.RiotApiDtos
{
    public class RiotApiSummonerSpell
    {
        public string Name { get; set; }

        public string Tooltip { get; set; }

        public string Description { get; set; }

        public double BaseCooldown { get; set; }

        public string ImageUrl { get; set; }
    }
}
