namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class ChampionRunesStatRune : BaseDeletableModel<int>
    {
        public virtual StatRune StatRune { get; set; }

        public int StatRuneId { get; set; }

        public virtual ChampionRunes ChampionRunes { get; set; }

        public int ChampionRunesId { get; set; }
    }
}
