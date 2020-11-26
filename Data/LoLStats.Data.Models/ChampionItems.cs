﻿namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionItems : BaseDeletableModel<int>
    {
        public ChampionItems()
        {
            this.Items = new HashSet<Item>();
        }

        public ICollection<Item> Items { get; set; }

        public int ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public decimal PickRate { get; set; }

        public decimal WinRate { get; set; }
    }
}
