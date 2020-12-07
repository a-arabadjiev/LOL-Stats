namespace LoLStats.Data.Models
{
    public class Passive
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public virtual Champion Champion { get; set; }

        public int ChampionId { get; set; }
    }
}
