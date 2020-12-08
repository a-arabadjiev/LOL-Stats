namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionInfo : BaseDeletableModel<int>
    {
        public byte Attack { get; set; }

        public byte Defense { get; set; }

        public byte Difficulty { get; set; }

        public byte Magic { get; set; }

        public virtual Champion Champion { get; set; }

        public int ChampionId { get; set; }
    }
}
