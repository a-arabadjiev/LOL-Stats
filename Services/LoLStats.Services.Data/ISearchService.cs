namespace LoLStats.Services.Data
{
    using System.Collections.Generic;

    public interface ISearchService
    {
        IEnumerable<T> ReturnChampions<T>(string input);
    }
}
