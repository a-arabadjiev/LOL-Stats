namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class AllyTip : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public virtual Champion Champion { get; set; }

        public int ChampionId { get; set; }
    }
}
