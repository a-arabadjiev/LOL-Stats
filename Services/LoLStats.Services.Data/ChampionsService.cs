namespace LoLStats.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LoLStats.Data;
    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;
    using LoLStats.Web.ViewModels.Abilities;
    using LoLStats.Web.ViewModels.Champions;
    using LoLStats.Web.ViewModels.Items;
    using LoLStats.Web.ViewModels.Runes;
    using LoLStats.Web.ViewModels.SummonerSpells;
    using Microsoft.EntityFrameworkCore;

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
        private readonly ISanitizerService sanitizerService;

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
            IDeletableEntityRepository<ChampionSummonerSpellsSummonerSpell> championSummonerSpellsSummonerSpellRepository,
            ISanitizerService sanitizerService)
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
            this.sanitizerService = sanitizerService;
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
            var dbChampion = await this.db.Champions
                .Include(x => x.Passive)
                .Include(x => x.BestAbilities).ThenInclude(x => x.Abilities).ThenInclude(x => x.PerLevelStats)
                .Include(x => x.BestStartingItems).ThenInclude(x => x.Items)
                .Include(x => x.BestItems).ThenInclude(x => x.Items)
                .Include(x => x.BestRunes).ThenInclude(x => x.Runes)
                .Include(x => x.BestSummonerSpells).ThenInclude(x => x.SummonerSpells)
                .Include(x => x.ChampionCounters)
                .Include(x => x.ChampionRoles)
                .AsSplitQuery()
                .FirstOrDefaultAsync<Champion>(x => x.Id == id);

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
                    ImagePath = $"/images/roles/{dbChampionRole.Role.ToString().ToLower()}.png",
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
            var dbBestSummonerSpells = dbChampion.BestSummonerSpells.FirstOrDefault();

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

            // ChampionRunes
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
                    IsActive = true,
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
                    RowId = statRune.RowId,
                    RuneType = statRune.RuneType.ToString(),
                    IsActive = true,
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
                    ImageUrl = counterChampion.ImageUrl,
                    TotalMatches = counterChampion.TotalMatches,
                    WinRate = counterChampion.WinRate,
                };

                championToAdd.ChampionCounters.Add(counterChampionToAdd);
            }

            // Runes
            var primaryRunes = this.db.Runes.Where(x => x.RunePathId == dbBestRunes.MainRuneTree.ToString()).ToList();
            var secondaryRunes = this.db.Runes.Where(x => x.RunePathId == dbBestRunes.SecondaryRuneTree.ToString()).ToList();

            foreach (var primaryRune in primaryRunes)
            {
                var primaryRuneToAdd = new RuneViewModel
                {
                    Name = primaryRune.Name,
                    IsKeystone = primaryRune.IsKeystone,
                    ImageUrl = primaryRune.ImageUrl,
                    ShortDescription = primaryRune.ShortDescription,
                    RunePath = primaryRune.RunePathId,
                    IsActive = championToAdd.BestRunes.FirstOrDefault()
                        .Runes
                        .Any(x => x.Name == primaryRune.Name),
                };

                if (!primaryRuneToAdd.IsActive)
                {
                    primaryRuneToAdd.ImageUrl = $"/images/runes/grayscaled/{primaryRune.RunePathId}/{this.sanitizerService.RemoveSpacesAndSymbols(primaryRune.Name)}.png";
                }

                championToAdd.AllPrimaryRunes.Add(primaryRuneToAdd);
            }

            foreach (var secondaryRune in secondaryRunes)
            {
                var secondaryRuneToAdd = new RuneViewModel
                {
                    Name = secondaryRune.Name,
                    IsKeystone = secondaryRune.IsKeystone,
                    ImageUrl = secondaryRune.ImageUrl,
                    ShortDescription = secondaryRune.ShortDescription,
                    RunePath = secondaryRune.RunePathId,
                    IsActive = championToAdd.BestRunes.FirstOrDefault()
                        .Runes
                        .Any(x => x.Name == secondaryRune.Name),
                };

                if (!secondaryRuneToAdd.IsActive)
                {
                    secondaryRuneToAdd.ImageUrl = $"/images/runes/grayscaled/{secondaryRune.RunePathId}/{this.sanitizerService.RemoveSpacesAndSymbols(secondaryRune.Name)}.png";
                }

                championToAdd.AllSecondaryRunes.Add(secondaryRuneToAdd);
            }

            // Stat Runes
            var statRunes = this.db.StatRunes.ToList();

            foreach (var statRune in statRunes)
            {
                var statRuneToAdd = new StatRuneViewModel
                {
                    RowId = statRune.RowId,
                    RuneType = statRune.RuneType.ToString(),
                    Description = statRune.Description,
                    ImagePath = statRune.ImagePath,
                    IsActive = championToAdd.BestRunes.FirstOrDefault()
                        .StatRunes
                        .Any(x => x.RowId == statRune.RowId && x.Description == statRune.Description),
                };

                if (!statRuneToAdd.IsActive)
                {
                    statRuneToAdd.ImagePath = statRuneToAdd.ImagePath.Insert(18, "/grayscaled/GS");
                }

                championToAdd.AllStatRunes.Add(statRuneToAdd);
            }

            championToAdd.BestRunes.First().StatRunes = championToAdd.BestRunes.First().StatRunes.Reverse().ToList();

            return championToAdd;
        }
    }
}
