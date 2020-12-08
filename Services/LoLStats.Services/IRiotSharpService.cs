namespace LoLStats.Services
{
    using System.Collections.Concurrent;

    using LoLStats.Services.Models.RiotApiDtos;

    public interface IRiotSharpService
    {
        string[] GetAllChampionKeys();

        ConcurrentBag<RiotApiChampionDto> ReturnChampionsData();

        ConcurrentBag<RiotApiItemDto> ReturnItemsData();

        ConcurrentBag<RiotApiRunePathDto> ReturnRunesData();

        ConcurrentBag<RiotApiSummonerSpellDto> ReturnSummonerSpellsData();
    }
}
