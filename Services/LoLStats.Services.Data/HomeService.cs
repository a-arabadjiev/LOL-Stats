namespace LoLStats.Services.Data
{
    using System.Linq;

    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Mapping;
    using LoLStats.Web.ViewModels.Home;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<ChampionRole> championRolesRepository;
        private readonly IDeletableEntityRepository<Champion> championsRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        private readonly IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository;
        private readonly IDeletableEntityRepository<Rune> runesRepository;

        public HomeService(
            IDeletableEntityRepository<ChampionRole> championRolesRepository,
            IDeletableEntityRepository<Champion> championsRepository,
            IDeletableEntityRepository<Item> itemsRepository,
            IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository,
            IDeletableEntityRepository<Rune> runesRepository)
        {
            this.championRolesRepository = championRolesRepository;
            this.championsRepository = championsRepository;
            this.itemsRepository = itemsRepository;
            this.summonerSpellsRepository = summonerSpellsRepository;
            this.runesRepository = runesRepository;
        }

        public BaseDataViewModel GetBaseGameCounts()
        {
            var baseCounts = new BaseDataViewModel
            {
                ChampionsCount = this.championsRepository.AllAsNoTracking().Count(),
                ItemsCount = this.itemsRepository.AllAsNoTracking().Count(),
                SummonerSpellsCount = this.summonerSpellsRepository.AllAsNoTracking().Count(),
                RunesCount = this.runesRepository.AllAsNoTracking().Count(),
            };

            return baseCounts;
        }

        public TopChampionsListViewModel GetTopChampionsForEachRole()
        {
            TopChampionsListViewModel topChampionsListViewModel = new TopChampionsListViewModel
            {
            };

            for (int i = 0; i < 5; i++)
            {
                double topChampionWinrate = this.championRolesRepository.AllAsNoTracking().Where(c => c.Role == (RoleType)i).Max(x => x.WinRate);
                TopChampionForRoleViewModel topChampionViewModel = this.championRolesRepository.AllAsNoTracking().To<TopChampionForRoleViewModel>().FirstOrDefault(w => w.WinRate == topChampionWinrate);

                topChampionsListViewModel.TopChampions.Add(topChampionViewModel);
            }

            return topChampionsListViewModel;
        }
    }
}
