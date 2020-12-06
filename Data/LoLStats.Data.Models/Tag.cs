namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Models.Enums;

    public class Tag
    {
        public TagType Name { get; set; }

        public ICollection<Champion> Champions { get; set; }
    }
}
