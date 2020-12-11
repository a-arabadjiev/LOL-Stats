namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class StatRune : BaseDeletableModel<int>
    {
        public StatRune()
        {
            this.ChampionRunes = new HashSet<ChampionRunes>();
        }

        // TODO
        public virtual StatRuneRow Row { get; set; }

        public StatRuneType RuneType { get; set; }

        public string RowId { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<ChampionRunes> ChampionRunes { get; set; }
    }
}
