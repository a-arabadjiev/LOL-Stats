namespace LoLStats.Services
{
    using System.Collections.Concurrent;

    using LoLStats.Services.Models;

    public interface IScraperService
    {
        ConcurrentBag<ChampionPageDto> ReturnChampionPageInfo();
    }
}
