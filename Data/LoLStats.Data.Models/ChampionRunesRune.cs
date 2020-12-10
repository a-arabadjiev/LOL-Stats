namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class ChampionRunesRune : BaseDeletableModel<int>
    {
        public virtual Rune Rune { get; set; }

        public int RuneId { get; set; }

        public virtual ChampionRunes ChampionRunes { get; set; }

        public int ChampionRunesId { get; set; }
    }
}
