namespace LoLStats.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Models.ScraperDtos;

    public class DbService : IDbService
    {
        private readonly IDeletableEntityRepository<Champion> championsRepository;
        private readonly IDeletableEntityRepository<ChampionAbilities> championAbilitiesRepository;
        private readonly IDeletableEntityRepository<ChampionItems> championItemsRepository;
        private readonly IDeletableEntityRepository<ChampionRole> championRolesRepository;
        private readonly IDeletableEntityRepository<ChampionRunes> championRunesRepository;
        private readonly IDeletableEntityRepository<ChampionStarterItems> championStarterItemsRepository;
        private readonly IDeletableEntityRepository<ChampionSummonerSpells> championSummonerSpellsRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        private readonly IDeletableEntityRepository<RunePath> runePathsRepository;
        private readonly IDeletableEntityRepository<Rune> runesRepository;
        private readonly IDeletableEntityRepository<StatRune> statRunesRepository;
        private readonly IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository;
        private readonly IDeletableEntityRepository<StatRuneRow> statRuneRowsRepository;
        private readonly IDeletableEntityRepository<CounterChampion> counterChampionsRepository;
        private readonly IDeletableEntityRepository<ChampionCounterChampions> championCounterChapmionsRepository;
        private readonly IDeletableEntityRepository<ChampionItemsItem> championItemsItemRepository;
        private readonly IDeletableEntityRepository<ChampionStarterItemsItem> championStarterItemsItemRepository;
        private readonly IDeletableEntityRepository<ChampionSummonerSpellsSummonerSpell> championSummonerSpellsSummonerSpellRepository;
        private readonly IDeletableEntityRepository<ChampionRunesRune> championRunesRuneRepository;
        private readonly IDeletableEntityRepository<ChampionRunesStatRune> championRunesStatRuneRepository;
        private readonly IDeletableEntityRepository<ChampionAbilitiesAbility> championAbilitiesAbilitiesRepository;
        private readonly IDeletableEntityRepository<BaseAbility> baseChampionAbilitiesRepository;
        private readonly IRiotSharpService riotSharpService;
        private readonly IScraperService scraperService;

        public DbService(
            IDeletableEntityRepository<CounterChampion> counterChampionsRepository,
            IDeletableEntityRepository<ChampionCounterChampions> championCounterChapmionsRepository,
            IDeletableEntityRepository<ChampionItemsItem> championItemsItemRepository,
            IDeletableEntityRepository<ChampionStarterItemsItem> championStarterItemsItemRepository,
            IDeletableEntityRepository<ChampionSummonerSpellsSummonerSpell> championSummonerSpellsSummonerSpellRepository,
            IDeletableEntityRepository<ChampionRunesRune> championRunesRuneRepository,
            IDeletableEntityRepository<ChampionRunesStatRune> championRunesStatRuneRepository,
            IDeletableEntityRepository<ChampionAbilitiesAbility> championAbilitiesAbilitiesRepository,
            IDeletableEntityRepository<BaseAbility> baseChampionAbilitiesRepository,
            IRiotSharpService riotSharpService,
            IScraperService scraperService,
            IDeletableEntityRepository<Champion> championsRepository,
            IDeletableEntityRepository<ChampionAbilities> championAbilitiesRepository,
            IDeletableEntityRepository<ChampionItems> championItemsRepository,
            IDeletableEntityRepository<ChampionRole> championRolesRepository,
            IDeletableEntityRepository<ChampionRunes> championRunesRepository,
            IDeletableEntityRepository<ChampionStarterItems> championStarterItemsRepository,
            IDeletableEntityRepository<ChampionSummonerSpells> championSummonerSpellsRepository,
            IDeletableEntityRepository<Item> itemsRepository,
            IDeletableEntityRepository<RunePath> runePathsRepository,
            IDeletableEntityRepository<Rune> runesRepository,
            IDeletableEntityRepository<StatRune> statRunesRepository,
            IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository,
            IDeletableEntityRepository<StatRuneRow> statRuneRowsRepository)
        {
            this.counterChampionsRepository = counterChampionsRepository;
            this.championCounterChapmionsRepository = championCounterChapmionsRepository;
            this.championItemsItemRepository = championItemsItemRepository;
            this.championStarterItemsItemRepository = championStarterItemsItemRepository;
            this.championSummonerSpellsSummonerSpellRepository = championSummonerSpellsSummonerSpellRepository;
            this.championRunesRuneRepository = championRunesRuneRepository;
            this.championRunesStatRuneRepository = championRunesStatRuneRepository;
            this.championAbilitiesAbilitiesRepository = championAbilitiesAbilitiesRepository;
            this.baseChampionAbilitiesRepository = baseChampionAbilitiesRepository;
            this.riotSharpService = riotSharpService;
            this.scraperService = scraperService;
            this.championsRepository = championsRepository;
            this.championAbilitiesRepository = championAbilitiesRepository;
            this.championItemsRepository = championItemsRepository;
            this.championRolesRepository = championRolesRepository;
            this.championRunesRepository = championRunesRepository;
            this.championStarterItemsRepository = championStarterItemsRepository;
            this.championSummonerSpellsRepository = championSummonerSpellsRepository;
            this.itemsRepository = itemsRepository;
            this.runePathsRepository = runePathsRepository;
            this.runesRepository = runesRepository;
            this.statRunesRepository = statRunesRepository;
            this.summonerSpellsRepository = summonerSpellsRepository;
            this.statRuneRowsRepository = statRuneRowsRepository;
        }

        public async Task AddBaseGameData()
        {
            await this.AddChampions();

            await this.AddItems();

            await this.AddSummonerSpells();

            await this.AddRunes();

            await this.AddStatRunes();
        }

        public async Task AddChampionStatisticsData()
        {
            var championPageDtos = this.scraperService.ReturnChampionPageInfo().ToArray();

            for (int i = 0; i < championPageDtos.Length; i++)
            {
                var championPageDto = championPageDtos[i];

                await this.AddChampionAbilitiesStatistics(championPageDto, i);

                await this.AddChampionRoleStatistics(championPageDto);

                await this.AddChampionSummonerSpellsStatistics(championPageDto, i);

                await this.AddChampionStarterItemsStatistics(championPageDto, i);

                await this.AddChampionItemsStatistics(championPageDto, i);

                await this.AddChampionRunesStatistics(championPageDto, i);

                await this.AddCounterChampionsStatistics(championPageDto, i);
            }
        }

        // Statistics
        private async Task AddCounterChampionsStatistics(ChampionPageDto championPageDto, int i)
        {
            foreach (var champion in championPageDto.CounterChampions)
            {
                var counterChampionId = this.championsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(c => c.Name.Contains(champion)).Id;

                var counterChampion = new CounterChampion
                {
                    Id = counterChampionId,
                    Name = champion,
                    TotalMatches = 0, // tempporary
                    WinRate = 0, // temporary
                };

                await this.counterChampionsRepository.AddAsync(counterChampion);

                var championCounterChampions = new ChampionCounterChampions
                {
                    ChampionId = championPageDto.Key,
                    CounterChapmionId = counterChampion.Id,
                };

                await this.championCounterChapmionsRepository.AddAsync(championCounterChampions);
            }

            await this.counterChampionsRepository.SaveChangesAsync();
            await this.championCounterChapmionsRepository.SaveChangesAsync();
        }

        private async Task AddChampionRunesStatistics(ChampionPageDto championPageDto, int i)
        {
            var championRunes = new ChampionRunes
            {
                ChampionId = championPageDto.Key,
                WinRate = championPageDto.RunesWinRate,
                TotalMatches = championPageDto.RunesMatchesCount,
                MainRuneTree = championPageDto.MainRuneTree,
                SecondaryRuneTree = championPageDto.SecondaryRuneTree,
            };

            await this.championRunesRepository.AddAsync(championRunes);
            await this.championRunesRepository.SaveChangesAsync();

            var primaryRunesAsArray = championPageDto.PrimaryRunes.ToArray();
            var secondaryRunesAsArray = championPageDto.SecondaryRunes.ToArray();

            var runeDtos = new string[primaryRunesAsArray.Length + secondaryRunesAsArray.Length];
            primaryRunesAsArray.CopyTo(runeDtos, 0);
            secondaryRunesAsArray.CopyTo(runeDtos, primaryRunesAsArray.Length);

            foreach (var runeDto in runeDtos)
            {
                var runeId = this.runesRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(r => r.Name == runeDto).Id;

                var championRunesRune = new ChampionRunesRune
                {
                    ChampionRunesId = i,
                    RuneId = runeId,
                };

                await this.championRunesRuneRepository.AddAsync(championRunesRune);
            }

            await this.championRunesRuneRepository.SaveChangesAsync();

            var statRunesAsArray = championPageDto.StatRunes.ToArray();

            for (int j = 0; j < statRunesAsArray.Length; j++)
            {
                var statRuneDto = statRunesAsArray[j];

                var statRuneId = this.statRunesRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(r => r.Row.Type == (StatRuneTreeType)j && r.Type == statRuneDto).Id;

                var championRunesStatRune = new ChampionRunesStatRune
                {
                    ChampionRunesId = i,
                    StatRuneId = statRuneId,
                };

                await this.championRunesStatRuneRepository.AddAsync(championRunesStatRune);
            }

            await this.championRunesStatRuneRepository.SaveChangesAsync();
        }

        private async Task AddChampionItemsStatistics(ChampionPageDto championPageDto, int i)
        {
            var championItems = new ChampionItems
            {
                ChampionId = championPageDto.Key,
                WinRate = (int)Math.Round(championPageDto.ItemsWinRateKvp.Values.Average()),
            };

            await this.championItemsRepository.AddAsync(championItems);
            await this.championItemsRepository.SaveChangesAsync();

            foreach (var itemDto in championPageDto.ItemsWinRateKvp.Keys)
            {
                var itemId = this.itemsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(x => x.Name == itemDto).Id;

                var championItemsItem = new ChampionItemsItem
                {
                    ItemId = itemId,
                    ChampionItemsId = i,
                };

                await this.championItemsItemRepository.AddAsync(championItemsItem);
            }

            await this.championItemsItemRepository.SaveChangesAsync();
        }

        private async Task AddChampionStarterItemsStatistics(ChampionPageDto championPageDto, int i)
        {
            var championStarterItems = new ChampionStarterItems
            {
                ChampionId = championPageDto.Key,
                WinRate = championPageDto.StartingItemsWinRate,
                PickRate = championPageDto.StartingItemsPickRate,
            };

            await this.championStarterItemsRepository.AddAsync(championStarterItems);
            await this.championStarterItemsRepository.SaveChangesAsync();

            foreach (var itemDto in championPageDto.StartingItems)
            {
                var itemId = this.itemsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(x => x.Name == itemDto).Id;

                var championStarterItemsItem = new ChampionStarterItemsItem
                {
                    ItemId = itemId,
                    ChampionStarterItemsId = i,
                };

                await this.championStarterItemsItemRepository.AddAsync(championStarterItemsItem);
            }

            await this.championStarterItemsItemRepository.SaveChangesAsync();
        }

        private async Task AddChampionSummonerSpellsStatistics(ChampionPageDto championPageDto, int i)
        {
            var championSummonerSpells = new ChampionSummonerSpells
            {
                ChampionId = championPageDto.Key,
                WinRate = championPageDto.SummonerSpellsWinRate,
                TotalMatches = championPageDto.SummonerSpellsTotalMatches,
            };

            await this.championSummonerSpellsRepository.AddAsync(championSummonerSpells);
            await this.championSummonerSpellsRepository.SaveChangesAsync();

            foreach (var spellDto in championPageDto.SummonerSpells)
            {
                var summonerSpellId = this.summonerSpellsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(s => s.Name == spellDto).Id;

                var championSummonerSpellsSummonerSpell = new ChampionSummonerSpellsSummonerSpell
                {
                    ChampionSummonerSpellsId = i,
                    SummonerSpellId = summonerSpellId,
                };

                await this.championSummonerSpellsSummonerSpellRepository.AddAsync(championSummonerSpellsSummonerSpell);
            }

            await this.championSummonerSpellsSummonerSpellRepository.SaveChangesAsync();
        }

        private async Task AddChampionRoleStatistics(ChampionPageDto championPageDto)
        {
            var championRole = new ChampionRole
            {
                ChampionId = championPageDto.Key,
                Role = championPageDto.Role,
                WinRate = championPageDto.ChampionWinRate,
                PickRate = championPageDto.ChampionPickRate,
                BanRate = championPageDto.ChampionBanRate,
                TotalMatches = championPageDto.ChampionTotalMatches,
                Tier = championPageDto.ChampionTier,
            };

            await this.championRolesRepository.AddAsync(championRole);
            await this.championRolesRepository.SaveChangesAsync();
        }

        private async Task AddChampionAbilitiesStatistics(ChampionPageDto championPageDto, int i)
        {
            var championAbilities = new ChampionAbilities
            {
                ChampionId = championPageDto.Key,
                WinRate = championPageDto.SkillsWinRate,
                TotalMatches = championPageDto.SkillsMatchesCount,
            };

            await this.championAbilitiesRepository.AddAsync(championAbilities);
            await this.championAbilitiesRepository.SaveChangesAsync();

            foreach (var abilityTypeDto in championPageDto.SkillsPriority)
            {
                var abilityId = this.baseChampionAbilitiesRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(a => a.Id == championPageDto.Key + abilityTypeDto).Id;

                var championAbilitiesAbility = new ChampionAbilitiesAbility
                {
                    BaseAbilityId = abilityId,
                    ChampionAbilitiesId = i,
                };

                await this.championAbilitiesAbilitiesRepository.AddAsync(championAbilitiesAbility);
            }

            await this.championAbilitiesAbilitiesRepository.SaveChangesAsync();
        }

        // Base Game
        private async Task AddChampions()
        {
            var championDtos = this.riotSharpService.ReturnChampionsData().OrderBy(x => x.Id).ToArray();

            for (int i = 0; i < championDtos.Length; i++)
            {
                var championDto = championDtos[i];

                var champion = new Champion
                {
                    Name = championDto.Name,
                    Id = championDto.Id,
                    Title = championDto.Title,
                    Lore = championDto.Lore,
                    ImageUrl = championDto.ImageUrl,
                    Partype = championDto.Partype,
                    IsFree = championDto.IsFree,
                    Passive = new ChampionPassive
                    {
                        Name = championDto.Passive.Name,
                        Description = championDto.Passive.Description,
                        ImageUrl = championDto.Passive.ImageUrl,
                        ChampionId = championDto.Id,
                    },
                    Info = new ChampionInfo
                    {
                        Attack = championDto.Info.Attack,
                        Defense = championDto.Info.Defense,
                        Magic = championDto.Info.Magic,
                        Difficulty = championDto.Info.Difficulty,
                        ChampionId = championDto.Id,
                    },
                    Stats = new ChampionStats
                    {
                        Armor = championDto.Stats.Armor,
                        ArmorPerLevel = championDto.Stats.Armor,
                        AttackDamage = championDto.Stats.Armor,
                        AttackDamagePerLevel = championDto.Stats.Armor,
                        AttackRange = championDto.Stats.Armor,
                        AttackSpeedOffset = championDto.Stats.Armor,
                        AttackSpeedPerLevel = championDto.Stats.Armor,
                        Crit = championDto.Stats.Armor,
                        CritPerLevel = championDto.Stats.Armor,
                        Hp = championDto.Stats.Armor,
                        HpPerLevel = championDto.Stats.Armor,
                        HpRegen = championDto.Stats.Armor,
                        HpRegenPerLevel = championDto.Stats.Armor,
                        MoveSpeed = championDto.Stats.Armor,
                        Mp = championDto.Stats.Armor,
                        MpPerLevel = championDto.Stats.Armor,
                        MpRegen = championDto.Stats.Armor,
                        MpRegenPerLevel = championDto.Stats.Armor,
                        SpellBlock = championDto.Stats.Armor,
                        SpellBlockPerLevel = championDto.Stats.Armor,
                        ChampionId = championDto.Id,
                    },
                };

                foreach (var tipDto in championDto.AllyTips)
                {
                    var allyTip = new AllyTip
                    {
                        Description = tipDto.Description,
                        ChampionId = championDto.Id,
                    };
                    champion.AllyTips.Add(allyTip);
                }

                foreach (var tipDto in championDto.EnemyTips)
                {
                    var enemyTip = new EnemyTip
                    {
                        Description = tipDto.Description,
                        ChampionId = championDto.Id,
                    };
                    champion.EnemyTips.Add(enemyTip);
                }

                var championSpellDtos = championDto.Spells.ToArray();
                for (int j = 0; j < championSpellDtos.Length; j++)
                {
                    var spellDto = championSpellDtos[j];

                    var championAbility = new BaseAbility
                    {
                        Name = spellDto.Name,
                        Id = spellDto.Id,
                        Description = spellDto.Description,
                        AbilityType = spellDto.AbilityType,
                        ImageUrl = spellDto.ImageUrl,
                        MaxRank = spellDto.MaxRank,
                        ChampionId = championDto.Id,
                    };

                    foreach (var stat in spellDto.PerLevelStats)
                    {
                        var perLevel = new AbilityPerLevel
                        {
                            Level = stat.Level,
                            BaseChampionAbilityId = spellDto.Id,
                            Cooldown = stat.Cooldown,
                            Range = stat.Range,
                            Cost = stat.Cost,
                            CostsPerSecond = stat.CostsPerSecond,
                        };

                        championAbility.PerLevelStats.Add(perLevel);
                    }

                    champion.BaseAbilities.Add(championAbility);
                }

                foreach (var tagDto in championDto.Tags)
                {
                    var tag = new Tag
                    {
                        Name = tagDto.Name,
                    };

                    champion.Tags.Add(tag);
                }

                await this.championsRepository.AddAsync(champion);
            }

            await this.championsRepository.SaveChangesAsync();
        }

        private async Task AddItems()
        {
            var itemDtos = this.riotSharpService.ReturnItemsData().ToArray();

            foreach (var itemDto in itemDtos)
            {
                var item = new Item
                {
                    Name = itemDto.Name,
                    Description = itemDto.Description,
                    FullCost = itemDto.FullCost,
                    IndividualCost = itemDto.IndividualCost,
                    SellingCost = itemDto.SellingCost,
                    ImageUrl = itemDto.ImageUrl,
                    IsPurchasable = itemDto.HideFromAll,
                };

                await this.itemsRepository.AddAsync(item);
            }

            await this.itemsRepository.SaveChangesAsync();
        }

        private async Task AddSummonerSpells()
        {
            var summonerSpellDtos = this.riotSharpService.ReturnSummonerSpellsData().ToArray();

            foreach (var spellDto in summonerSpellDtos)
            {
                var summonerSpell = new SummonerSpell
                {
                    Name = spellDto.Name,
                    Description = spellDto.Description,
                    BaseCooldown = spellDto.BaseCooldown,
                    ImageUrl = spellDto.ImageUrl,
                    Key = spellDto.Key,
                    Tooltip = spellDto.Tooltip,
                };

                await this.summonerSpellsRepository.AddAsync(summonerSpell);
            }

            await this.summonerSpellsRepository.SaveChangesAsync();
        }

        private async Task AddRunes()
        {
            var runeTreeDtos = this.riotSharpService.ReturnRunesData().ToArray();

            foreach (var runeTreeDto in runeTreeDtos)
            {
                var runeTree = new RunePath
                {
                    Name = runeTreeDto.Name,
                    ImageUrl = runeTreeDto.ImageUrl,
                    Id = runeTreeDto.Id,
                };

                foreach (var runeDto in runeTreeDto.RuneDtos)
                {
                    var rune = new Rune
                    {
                        Name = runeDto.Name,
                        LongDescription = runeDto.LongDescription,
                        ShortDescription = runeDto.ShortDescription,
                        ImageUrl = runeDto.ImageUrl,
                        IsKeystone = runeDto.IsKeystone,
                        RunePathId = runeTree.Id,
                    };

                    runeTree.Runes.Add(rune);
                }

                await this.runePathsRepository.AddAsync(runeTree);
            }

            await this.runePathsRepository.SaveChangesAsync();
        }

        private async Task AddStatRunes()
        {
            // Add StatRunes
            string[] offenseRuneValues = { "Adaptive Force +9", "Attack Speed +9%", "Ability Haste +8 (Based on level)" };
            string[] flexRuneValues = { "Adaptive Force +9", "Armor +6", "Magic Resist +8" };
            string[] defenseRuneValues = { "Health +15-90 (Based on level)", "Armor +6", "Magic Resist +8" };

            string[][] valueRows = { offenseRuneValues, flexRuneValues, defenseRuneValues };

            for (int i = 0; i < 3; i++)
            {
                var runeRow = new StatRuneRow
                {
                    Type = (StatRuneTreeType)i,
                    Id = ((StatRuneTreeType)i).ToString(),
                };
                for (int j = 0; j < 3; j++)
                {
                    string currentDescription = valueRows[i][j];

                    runeRow.Runes.Add(new StatRune
                    {
                        RowId = runeRow.Id,
                        Description = currentDescription,
                        ImagePath = $"wwwroot/images/statrunes/{currentDescription.Split(" ").First()}.png",
                    });
                }

                await this.statRuneRowsRepository.AddAsync(runeRow);
            }

            await this.statRuneRowsRepository.SaveChangesAsync();
        }
    }
}
