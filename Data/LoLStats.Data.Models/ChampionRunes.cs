namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class ChampionRunes : BaseDeletableModel<int>
    {
        public ChampionRunes()
        {
            this.Runes = new HashSet<Rune>();
            this.StatRunes = new HashSet<StatRune>();
        }

        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public RuneTreeType MainRuneTree { get; set; }

        public RuneTreeType SecondaryRuneTree { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public virtual ICollection<Rune> Runes { get; set; }

        public virtual ICollection<StatRune> StatRunes { get; set; }
    }
}
