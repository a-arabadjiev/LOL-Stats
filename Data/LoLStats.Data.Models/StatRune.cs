namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class StatRune : BaseDeletableModel<int>
    {
        // TODO
        public StatRuneType Type { get; set; }

        public string Description { get; set; }
    }
}
