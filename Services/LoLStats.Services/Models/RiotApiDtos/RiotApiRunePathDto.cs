namespace LoLStats.Services.Models.RiotApiDtos
{
    using System.Collections.Generic;

    using LoLStats.Data.Models;
    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Mapping;

    public class RiotApiRunePathDto : IMapTo<RunePath>
    {
        public RuneTreeType Name { get; set; }

        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<RiotApiRuneDto> RuneDtos { get; set; }
    }
}
