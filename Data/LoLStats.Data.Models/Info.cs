namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class Info : BaseDeletableModel<int>
    {
        public Info()
        {
            this.Champions = new HashSet<Champion>();
        }

        public byte Attack { get; set; }

        public byte Defense { get; set; }

        public byte Difficulty { get; set; }

        public byte Magic { get; set; }

        public virtual ICollection<Champion> Champions { get; set; }
    }
}
