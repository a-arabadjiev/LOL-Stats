namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class ChampionItemsItem : BaseDeletableModel<int>
    {
        public virtual Item Item { get; set; }

        public int ItemId { get; set; }

        public virtual ChampionItems ChampionItems { get; set; }

        public int ChampionItemsId { get; set; }
    }
}
