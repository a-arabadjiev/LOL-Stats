namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models;
    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Mapping;

    public class RiotApiChampionTagDto : IMapTo<Tag>
    {
        public TagType Name { get; set; }
    }
}
