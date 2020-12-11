namespace LoLStats.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;
    using LoLStats.Web.ViewModels.Champions;

    public class ChampionsService : IChampionsService
    {
        private readonly IDeletableEntityRepository<Champion> championsRepository;

        public ChampionsService(IDeletableEntityRepository<Champion> championsRepository)
        {
            this.championsRepository = championsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var champions = this.championsRepository.AllAsNoTracking()
                .OrderBy(c => c.Name)
                .To<T>()
                .ToList();

            return champions;
        }

        //public T GetById<T>()
        //{
        //    return <this.championsRepository.AllAsNoTracking().First();
        //}
    }
}
