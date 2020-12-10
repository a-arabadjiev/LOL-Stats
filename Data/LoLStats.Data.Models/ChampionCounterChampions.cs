namespace LoLStats.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LoLStats.Data.Common.Models;

    public class ChampionCounterChampions : BaseDeletableModel<int>
    {
        public virtual Champion Champion { get; set; }

        public string ChampionId { get; set; }

        public virtual CounterChampion CounterChampion { get; set; }

        public string CounterChapmionId { get; set; }
    }
}
