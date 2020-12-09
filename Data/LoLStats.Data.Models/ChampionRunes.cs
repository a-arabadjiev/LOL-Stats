namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionRunes : BaseDeletableModel<int>
    {
        public ChampionRunes()
        {
            this.Runes = new HashSet<Rune>();
            this.StatRunes = new HashSet<StatRune>();
        }

        public decimal PickRate { get; set; }

        public decimal WinRate { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public virtual ICollection<Rune> Runes { get; set; }

        public virtual ICollection<StatRune> StatRunes { get; set; }
    }
}
