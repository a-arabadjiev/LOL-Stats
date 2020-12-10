namespace LoLStats.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LoLStats.Data.Common.Models;

    public class CounterChampion : BaseDeletableModel<string>
    {
        public CounterChampion()
        {
            this.Champions = new HashSet<Champion>();
        }

        public string Name { get; set; }

        public double WinRate { get; set; }

        public int TotalMatches { get; set; }

        public virtual ICollection<Champion> Champions { get; set; }
    }
}
