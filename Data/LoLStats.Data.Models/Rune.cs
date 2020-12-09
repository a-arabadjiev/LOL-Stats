﻿namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class Rune : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public bool IsKeystone { get; set; }

        public string LongDescription { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public virtual RunePath RunePath { get; set; }

        public string RunePathId { get; set; }
    }
}
