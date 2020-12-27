namespace LoLStats.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class SummonerSpellsService : ISummonerSpellsService
    {
        private readonly IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository;

        public SummonerSpellsService(IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository)
        {
            this.summonerSpellsRepository = summonerSpellsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var summonerSpells = this.summonerSpellsRepository.AllAsNoTracking()
                .Where(x => !x.Key.Contains("Poro") && !x.Key.Contains("Snow"))
                .To<T>()
                .ToList();

            return summonerSpells;
        }
    }
}
