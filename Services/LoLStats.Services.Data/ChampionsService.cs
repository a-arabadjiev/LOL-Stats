namespace LoLStats.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data;

    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;
    using LoLStats.Web.ViewModels.Abilities;
    using LoLStats.Web.ViewModels.Champions;
    using LoLStats.Web.ViewModels.Items;
    using LoLStats.Web.ViewModels.Runes;
    using LoLStats.Web.ViewModels.SummonerSpells;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ChampionsService : IChampionsService
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Champion> championsRepository;
        private readonly IDeletableEntityRepository<ChampionRole> championRolesRepository;
        private readonly IDeletableEntityRepository<ChampionPassive> championPassivesRepository;
        private readonly IDeletableEntityRepository<ChampionAbilities> championAbilitiesRepository;
        private readonly IDeletableEntityRepository<AbilityPerLevel> abilitiesPerLevelRepository;
        private readonly IDeletableEntityRepository<ChampionSummonerSpells> championSummonerSpellsRepository;
        private readonly IDeletableEntityRepository<BaseAbility> baseAbilitiesRepository;
        private readonly IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository;
        private readonly IDeletableEntityRepository<ChampionSummonerSpellsSummonerSpell> championSummonerSpellsSummonerSpellRepository;

        public ChampionsService(
            ApplicationDbContext db,
            IDeletableEntityRepository<Champion> championsRepository,
            IDeletableEntityRepository<ChampionRole> championRolesRepository,
            IDeletableEntityRepository<ChampionPassive> championPassivesRepository,
            IDeletableEntityRepository<ChampionAbilities> championAbilitiesRepository,
            IDeletableEntityRepository<AbilityPerLevel> abilitiesPerLevelRepository,
            IDeletableEntityRepository<ChampionSummonerSpells> championSummonerSpellsRepository,
            IDeletableEntityRepository<BaseAbility> baseAbilitiesRepository,
            IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository,
            IDeletableEntityRepository<ChampionSummonerSpellsSummonerSpell> championSummonerSpellsSummonerSpellRepository)
        {
            this.db = db;
            this.championsRepository = championsRepository;
            this.championRolesRepository = championRolesRepository;
            this.championPassivesRepository = championPassivesRepository;
            this.championAbilitiesRepository = championAbilitiesRepository;
            this.abilitiesPerLevelRepository = abilitiesPerLevelRepository;
            this.championSummonerSpellsRepository = championSummonerSpellsRepository;
            this.baseAbilitiesRepository = baseAbilitiesRepository;
            this.summonerSpellsRepository = summonerSpellsRepository;
            this.championSummonerSpellsSummonerSpellRepository = championSummonerSpellsSummonerSpellRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var champions = this.championsRepository.AllAsNoTracking()
                .OrderBy(c => c.Name)
                .To<T>()
                .ToList();

            return champions;
        }

        public async Task<ChampionStatsViewModel> GetById(string id)
        {
            ChampionStatsViewModel championToAdd = await this.ReturnChampionStatsViewModel(id);

            return championToAdd;
        }

        private async Task<ChampionStatsViewModel> ReturnChampionStatsViewModel(string id)
        {
            var dbChampion = this.db.Champions
                .Include(x => x.Passive)
                .Include(x => x.BestAbilities).ThenInclude(x => x.Abilities).ThenInclude(x => x.PerLevelStats)
                .Include(x => x.BestStartingItems).ThenInclude(x => x.Items)
                .Include(x => x.BestItems).ThenInclude(x => x.Items)
                .Include(x => x.BestRunes).ThenInclude(x => x.Runes)
                .Include(x => x.BestSummonerSpells).ThenInclude(x => x.SummonerSpells)
                .Include(x => x.ChampionCounters)
                .Include(x => x.ChampionRoles)
                .AsSplitQuery()
                .FirstOrDefaultAsync<Champion>(x => x.Id == id).GetAwaiter().GetResult();

            var dbChampionRole = dbChampion.ChampionRoles.FirstOrDefault();

            // Champion
            ChampionStatsViewModel championToAdd = new ChampionStatsViewModel
            {
                Name = dbChampion.Name,
                ImageUrl = dbChampion.ImageUrl,
                IsFree = false,
                Passive = new ChampionPassiveViewModel
                {
                    Name = dbChampion.Passive.Name,
                    ChampionId = dbChampion.Passive.ChampionId,
                    Description = dbChampion.Passive.Description,
                    ImageUrl = dbChampion.Passive.ImageUrl,
                },

                ChampionRole = new ChampionRoleViewModel
                {
                    WinRate = dbChampionRole.WinRate,
                    BanRate = dbChampionRole.BanRate,
                    PickRate = dbChampionRole.PickRate,
                    TotalMatches = dbChampionRole.TotalMatches,
                    Role = dbChampionRole.Role.ToString(),
                    Tier = dbChampionRole.Tier,
                },
            };

            // Abilities
            var dbBestAbilities = dbChampion.BestAbilities.FirstOrDefault();

            var championAbilitiesToAdd = new ChampionAbilitiesViewModel
            {
                WinRate = dbBestAbilities.WinRate,
                TotalMatches = dbBestAbilities.TotalMatches,
            };

            var dbAbilities = dbBestAbilities.Abilities;

            foreach (var ability in dbAbilities)
            {
                var abilityToAdd = new BaseAbilityViewModel
                {
                    AbilityType = ability.AbilityType.ToString(),
                    Description = ability.Description,
                    ImageUrl = ability.ImageUrl,
                    MaxRank = ability.MaxRank,
                    Name = ability.Name,
                };

                var dbStatsPerLevel = ability.PerLevelStats;

                foreach (var stats in ability.PerLevelStats)
                {
                    var statsToAdd = new PerLevelStatViewModel
                    {
                        Level = stats.Level,
                        Cooldown = stats.Cooldown,
                        Cost = stats.Cost,
                        CostsPerSecond = stats.CostsPerSecond,
                        Range = stats.Range,
                    };

                    abilityToAdd.PerLevelStats.Add(statsToAdd);
                }

                championAbilitiesToAdd.Abilities.Add(abilityToAdd);
            }

            championToAdd.BestAbilities.Add(championAbilitiesToAdd);

            // Summoner Spells
            var dbBestSummonerSpells = this.championSummonerSpellsRepository.AllAsNoTracking().Where(x => x.ChampionId == id).FirstOrDefault();

            var championSummonerSpellsToAdd = new ChampionSummonerSpellsViewModel
            {
                WinRate = dbBestSummonerSpells.WinRate,
                TotalMatches = dbBestSummonerSpells.TotalMatches,
            };

            foreach (var spell in dbBestSummonerSpells.SummonerSpells)
            {
                var summonerSpellToAdd = new SummonerSpellViewModel
                {
                    Name = spell.Name,
                    Description = spell.Description,
                    BaseCooldown = spell.BaseCooldown,
                    ImageUrl = spell.ImageUrl,
                    Tooltip = spell.Tooltip,
                };

                championSummonerSpellsToAdd.SummonerSpells.Add(summonerSpellToAdd);
            }

            championToAdd.BestSummonerSpells.Add(championSummonerSpellsToAdd);

            // Starting Items
            var dbBestStarterItems = dbChampion.BestStartingItems.FirstOrDefault();

            var championStarterItemsToAdd = new ChampionStarterItemsViewModel
            {
                WinRate = dbBestStarterItems.WinRate,
                PickRate = dbBestStarterItems.PickRate,
            };

            foreach (var item in dbBestStarterItems.Items)
            {
                var itemToAdd = new ItemViewModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    FullCost = item.FullCost,
                };

                championStarterItemsToAdd.Items.Add(itemToAdd);
            }

            championToAdd.BestStartingItems.Add(championStarterItemsToAdd);

            // Main Items
            var dbBestItems = dbChampion.BestItems.FirstOrDefault();

            var championItemsToAdd = new ChampionItemsViewModel
            {
                WinRate = dbBestStarterItems.WinRate,
            };

            foreach (var item in dbBestItems.Items)
            {
                var itemToAdd = new ItemViewModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    FullCost = item.FullCost,
                };

                championItemsToAdd.Items.Add(itemToAdd);
            }

            championToAdd.BestItems.Add(championItemsToAdd);

            // Runes
            var dbBestRunes = dbChampion.BestRunes.FirstOrDefault();

            var championRunesToAdd = new ChampionRunesViewModel
            {
                WinRate = dbBestRunes.WinRate,
                TotalMatches = dbBestRunes.TotalMatches,
                MainRuneTree = dbBestRunes.MainRuneTree.ToString(),
                SecondaryRuneTree = dbBestRunes.SecondaryRuneTree.ToString(),
            };

            foreach (var rune in dbBestRunes.Runes)
            {
                var runeToAdd = new RuneViewModel
                {
                    Name = rune.Name,
                    ShortDescription = rune.ShortDescription,
                    ImageUrl = rune.ImageUrl,
                    IsKeystone = rune.IsKeystone,
                    RunePath = rune.RunePathId,
                };

                championRunesToAdd.Runes.Add(runeToAdd);
            }

            var dbBestStatRunes = await this.db.ChampionsRunes.Where(x => x.ChampionId == id).Include(x => x.StatRunes).AsSplitQuery().FirstOrDefaultAsync<ChampionRunes>();

            foreach (var statRune in dbBestStatRunes.StatRunes)
            {
                var statRuneToAdd = new StatRuneViewModel
                {
                    Description = statRune.Description,
                    ImagePath = statRune.ImagePath,
                    Row = statRune.RowId,
                    RuneType = statRune.RuneType.ToString(),
                };

                championRunesToAdd.StatRunes.Add(statRuneToAdd);
            }

            championToAdd.BestRunes.Add(championRunesToAdd);

            // ChampionCounters
            foreach (var counterChampion in dbChampion.ChampionCounters)
            {
                var counterChampionToAdd = new ChampionCounterViewModel
                {
                    CounterChapmionKey = counterChampion.CounterChapmionKey,
                    CounterChampionName = counterChampion.CounterChampionName,
                    TotalMatches = counterChampion.TotalMatches,
                    WinRate = counterChampion.WinRate,
                };

                championToAdd.ChampionCounters.Add(counterChampionToAdd);
            }

            return championToAdd;
        }
    }
}
