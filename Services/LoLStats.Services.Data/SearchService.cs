namespace LoLStats.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class SearchService : ISearchService
    {
        private readonly IDeletableEntityRepository<Champion> championsRepository;

        public SearchService(IDeletableEntityRepository<Champion> championsRepository)
        {
            this.championsRepository = championsRepository;
        }

        public IEnumerable<T> ReturnChampions<T>(string input)
        {
            var championsList = this.championsRepository.AllAsNoTracking()
                .Where(x => x.Name.Contains(input) || x.Id.Contains(input))
                .To<T>()
                .ToList();

            return championsList;
        }
    }
}
