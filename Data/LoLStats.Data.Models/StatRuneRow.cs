namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class StatRuneRow : BaseDeletableModel<string>
    {
        public StatRuneRow()
        {
            this.Runes = new HashSet<StatRune>();
        }

        public StatRuneTreeType Type { get; set; }

        public virtual ICollection<StatRune> Runes { get; set; }
    }
}
