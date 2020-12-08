namespace LoLStats.Services.Models.RiotApiDtos
{
    using System.Collections.Generic;

    using LoLStats.Data.Models.Enums;

    public class RiotApiRunePathDto
    {
        public RunePathType Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<RiotApiRuneDto> RuneDtos { get; set; }
    }
}
