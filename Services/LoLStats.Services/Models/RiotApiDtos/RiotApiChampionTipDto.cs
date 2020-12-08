namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class RiotApiChampionTipDto : IMapTo<AllyTip>, IMapTo<EnemyTip>
    {
        public string Description { get; set; }
    }
}
