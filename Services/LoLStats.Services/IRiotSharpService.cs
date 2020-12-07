namespace LoLStats.Services
{
    using System.Collections.Concurrent;

    using LoLStats.Services.Models.RiotApiDtos;

    public interface IRiotSharpService
    {
        string[] GetAllChampionKeys();

        ConcurrentBag<RiotApiChampionDto> ReturnChampionsData();

        ConcurrentBag<RiotApiChampionDto> ReturnItemsData();

        ConcurrentBag<RiotApiChampionDto> ReturnRunesData();

        ConcurrentBag<RiotApiChampionDto> ReturnSummonerSpellsData();
    }
}
