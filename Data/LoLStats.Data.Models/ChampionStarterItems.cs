namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionStarterItems : BaseDeletableModel<int>
    {
        public ChampionStarterItems()
        {
            this.Items = new HashSet<Item>();
        }

        public string ItemPriority { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public int PickRate { get; set; }

        public int WinRate { get; set; }
    }
}
