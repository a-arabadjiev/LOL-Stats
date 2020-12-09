namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class EnemyTip : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public virtual Champion Champion { get; set; }

        public string ChampionId { get; set; }
    }
}
