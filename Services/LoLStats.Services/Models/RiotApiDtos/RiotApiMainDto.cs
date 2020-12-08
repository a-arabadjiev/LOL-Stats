namespace LoLStats.Services.Models.RiotApiDtos
{
    using System.Collections.Generic;

    public class RiotApiMainDto
    {
        public ICollection<RiotApiChampionDto> ChampionDtos { get; set; }

        public ICollection<RiotApiItemDto> ItemDtos { get; set; }

        public ICollection<RiotApiRuneDto> RuneDtos { get; set; }

        public ICollection<RiotApiSummonerSpellDto> SummonerSpellDtos { get; set; }
    }
}
