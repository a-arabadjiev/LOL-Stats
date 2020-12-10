namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class ChampionItems : BaseDeletableModel<int>
    {
        public ChampionItems()
        {
            this.Items = new HashSet<Item>();
        }

        public virtual ICollection<Item> Items { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public int WinRate { get; set; }
    }
}
