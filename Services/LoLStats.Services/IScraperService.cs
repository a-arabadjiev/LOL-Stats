namespace LoLStats.Services
{
    using System.Collections.Concurrent;

    using LoLStats.Services.Models.ScraperDtos;

    public interface IScraperService
    {
        ConcurrentBag<ChampionPageDto> ReturnChampionPageInfo();
    }
}
