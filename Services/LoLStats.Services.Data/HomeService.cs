namespace LoLStats.Services.Data
{
    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Web.ViewModels.Home;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Champion> championsRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        private readonly IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository;
        private readonly IDeletableEntityRepository<Rune> runesRepository;

        public HomeService(
            IDeletableEntityRepository<Champion> championsRepository,
            IDeletableEntityRepository<Item> itemsRepository,
            IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository,
            IDeletableEntityRepository<Rune> runesRepository)
        {
            this.championsRepository = championsRepository;
            this.itemsRepository = itemsRepository;
            this.summonerSpellsRepository = summonerSpellsRepository;
            this.runesRepository = runesRepository;
        }

        public LoLBaseDataViewModel GetBaseGameCounts()
        {
            var baseCounts = new LoLBaseDataViewModel
            {
                ChampionsCount = this.championsRepository.AllAsNoTracking().Count(),
                ItemsCount = this.itemsRepository.AllAsNoTracking().Count(),
                SummonerSpellsCount = this.summonerSpellsRepository.AllAsNoTracking().Count(),
                RunesCount = this.runesRepository.AllAsNoTracking().Count(),
            };

            return baseCounts;
        }
    }
}
