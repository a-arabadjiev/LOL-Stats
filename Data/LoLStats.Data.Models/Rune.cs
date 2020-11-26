namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class Rune : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public bool IsKeystone { get; set; }

        public string Description { get; set; }

        public RunePath RunePath { get; set; }

        public int ChampionRunesId { get; set; }

        public virtual ChampionRunes ChampionRunes { get; set; }
    }
}
