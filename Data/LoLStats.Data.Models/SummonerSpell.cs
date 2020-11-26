namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class SummonerSpell : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int BaseCooldown { get; set; }
    }
}
