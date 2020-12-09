namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class StatRune : BaseDeletableModel<int>
    {
        // TODO
        public virtual StatRuneRow Row { get; set; }

        public string RowId { get; set; }

        public string Description { get; set; }
    }
}
