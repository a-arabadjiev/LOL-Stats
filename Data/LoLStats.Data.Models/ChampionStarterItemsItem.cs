namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class ChampionStarterItemsItem : BaseDeletableModel<int>
    {
        public virtual Item Item { get; set; }

        public int ItemId { get; set; }

        public virtual ChampionStarterItems ChampionStarterItems { get; set; }

        public int ChampionStarterItemsId { get; set; }
    }
}
