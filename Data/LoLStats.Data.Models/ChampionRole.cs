namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class ChampionRole : BaseDeletableModel<int>
    {
        public decimal PickRate { get; set; }

        public decimal WinRate { get; set; }

        public Role Role { get; set; }

        public string ChampionId { get; set; }

        public virtual Champion Champion { get; set; }
    }
}
