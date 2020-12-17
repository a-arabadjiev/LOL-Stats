namespace LoLStats.Services
{
    using System;
    using System.Collections.Generic;
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
        private readonly IDeletableEntityRepository<ChampionCounter> championCountersRepository;
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
            IDeletableEntityRepository<ChampionCounter> championCountersRepository,
            IDeletableEntityRepository<ChampionItemsItem> championItemsItemRepository,
            IDeletableEntityRepository<ChampionStarterItemsItem> championStarterItemsItemRepository,
            IDeletableEntityRepository<ChampionSummonerSpellsSummonerSpell> championSummonerSpellsSummonerSpellRepository,
            IDeletableEntityRepository<ChampionRunesRune> championRunesRuneRepository,
            IDeletableEntityRepository<ChampionRunesStatRune> championRunesStatRuneRepository,
            IDeletableEntityRepository<ChampionAbilitiesAbility> championAbilitiesAbilitiesRepository,
            IDeletableEntityRepository<BaseAbility> baseChampionAbilitiesRepository,
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
            IDeletableEntityRepository<StatRuneRow> statRuneRowsRepository,
            IRiotSharpService riotSharpService,
            IScraperService scraperService)
        {
            this.championCountersRepository = championCountersRepository;
            this.championCountersRepository = championCountersRepository;
            this.championItemsItemRepository = championItemsItemRepository;
            this.championStarterItemsItemRepository = championStarterItemsItemRepository;
            this.championSummonerSpellsSummonerSpellRepository = championSummonerSpellsSummonerSpellRepository;
            this.championRunesRuneRepository = championRunesRuneRepository;
            this.championRunesStatRuneRepository = championRunesStatRuneRepository;
            this.championAbilitiesAbilitiesRepository = championAbilitiesAbilitiesRepository;
            this.baseChampionAbilitiesRepository = baseChampionAbilitiesRepository;
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

            this.riotSharpService = riotSharpService;
            this.scraperService = scraperService;
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

                await this.AddChampionAbilitiesStatistics(championPageDto);

                await this.AddChampionRoleStatistics(championPageDto);

                await this.AddChampionSummonerSpellsStatistics(championPageDto);

                await this.AddChampionStarterItemsStatistics(championPageDto);

                await this.AddChampionItemsStatistics(championPageDto);

                await this.AddChampionRunesStatistics(championPageDto);

                await this.AddCounterChampionsStatistics(championPageDto);
            }

            await this.championsRepository.SaveChangesAsync();
        }

        // Statistics
        private async Task AddCounterChampionsStatistics(ChampionPageDto championPageDto)
        {
            foreach (var champion in championPageDto.CounterChampions)
            {
                var counterChampion = this.championsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(c => c.Name.Contains(champion));

                var championCounter = new ChampionCounter
                {
                    ChampionId = championPageDto.Key,
                    CounterChampionName = counterChampion.Name,
                    CounterChapmionKey = counterChampion.Id,
                };

                await this.championCountersRepository.AddAsync(championCounter);

                this.championsRepository.GetByIdWithDeletedAsync(championPageDto.Key).Result.ChampionCounters.Add(championCounter);
            }

            await this.championCountersRepository.SaveChangesAsync();
        }

        private async Task AddChampionRunesStatistics(ChampionPageDto championPageDto)
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

            var championRunesId = this.championRunesRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.ChampionId == championPageDto.Key
                 && x.WinRate == championPageDto.RunesWinRate
                 && x.TotalMatches == championPageDto.RunesMatchesCount).Id;

            var dbChampionRunes = this.championRunesRepository.All().FirstOrDefault(x => x.Id == championRunesId);

            foreach (var runeDto in runeDtos)
            {
                var runeId = this.runesRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(r => r.Name.Contains(runeDto)).Id;

                var runeToAdd = await this.runesRepository.GetByIdWithDeletedAsync(runeId);
                dbChampionRunes.Runes.Add(runeToAdd);

                var championRunesRune = new ChampionRunesRune
                {
                    ChampionRunesId = championRunesId,
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
                    .FirstOrDefault(r => r.Row.Type == (StatRuneTreeType)j && r.RuneType == statRuneDto).Id;

                var statRuneToAdd = await this.statRunesRepository.GetByIdWithDeletedAsync(statRuneId);
                dbChampionRunes.StatRunes.Add(statRuneToAdd);

                var championRunesStatRune = new ChampionRunesStatRune
                {
                    ChampionRunesId = championRunesId,
                    StatRuneId = statRuneId,
                };

                await this.championRunesStatRuneRepository.AddAsync(championRunesStatRune);
            }

            this.championRunesRepository.Update(dbChampionRunes);

            await this.championRunesStatRuneRepository.SaveChangesAsync();

            this.championsRepository.GetByIdWithDeletedAsync(championPageDto.Key).Result.BestRunes.Add(championRunes);
        }

        private async Task AddChampionItemsStatistics(ChampionPageDto championPageDto)
        {
            var championItems = new ChampionItems
            {
                ChampionId = championPageDto.Key,
                WinRate = (int)Math.Round(championPageDto.ItemsWinRateKvp.Values.Average()),
            };

            await this.championItemsRepository.AddAsync(championItems);
            await this.championItemsRepository.SaveChangesAsync();

            var championItemsId = this.championItemsRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.ChampionId == championPageDto.Key
                 && x.WinRate == championItems.WinRate).Id;

            var dbChampionItems = this.championItemsRepository.All().FirstOrDefault(x => x.Id == championItemsId);

            foreach (var itemDto in championPageDto.ItemsWinRateKvp.Keys.Where(i => i != string.Empty))
            {
                var itemId = this.itemsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(x => x.Name.Contains(itemDto)).Id;

                var itemToAdd = await this.itemsRepository.GetByIdWithDeletedAsync(itemId);
                dbChampionItems.Items.Add(itemToAdd);

                var championItemsItem = new ChampionItemsItem
                {
                    ItemId = itemId,
                    ChampionItemsId = championItemsId,
                };

                await this.championItemsItemRepository.AddAsync(championItemsItem);
            }

            this.championItemsRepository.Update(dbChampionItems);

            await this.championItemsItemRepository.SaveChangesAsync();

            this.championsRepository.GetByIdWithDeletedAsync(championPageDto.Key).Result.BestItems.Add(championItems);
        }

        private async Task AddChampionStarterItemsStatistics(ChampionPageDto championPageDto)
        {
            var championStarterItems = new ChampionStarterItems
            {
                ChampionId = championPageDto.Key,
                WinRate = championPageDto.StartingItemsWinRate,
                PickRate = championPageDto.StartingItemsPickRate,
            };

            await this.championStarterItemsRepository.AddAsync(championStarterItems);
            await this.championStarterItemsRepository.SaveChangesAsync();

            var championStarterItemsId = this.championStarterItemsRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.ChampionId == championPageDto.Key
                && x.PickRate == championPageDto.StartingItemsPickRate && x.WinRate == championPageDto.StartingItemsWinRate).Id;

            var dbChampionItems = this.championStarterItemsRepository.All().FirstOrDefault(x => x.Id == championStarterItemsId);

            foreach (var itemDto in championPageDto.StartingItems.Where(i => i != string.Empty))
            {
                var itemId = this.itemsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(x => x.Name.Contains(itemDto)).Id;

                var itemToAdd = await this.itemsRepository.GetByIdWithDeletedAsync(itemId);
                dbChampionItems.Items.Add(itemToAdd);

                var championStarterItemsItem = new ChampionStarterItemsItem
                {
                    ItemId = itemId,
                    ChampionStarterItemsId = championStarterItemsId,
                };

                await this.championStarterItemsItemRepository.AddAsync(championStarterItemsItem);
            }

            this.championStarterItemsRepository.Update(dbChampionItems);

            await this.championStarterItemsItemRepository.SaveChangesAsync();

            this.championsRepository.GetByIdWithDeletedAsync(championPageDto.Key).Result.BestStartingItems.Add(championStarterItems);
        }

        private async Task AddChampionSummonerSpellsStatistics(ChampionPageDto championPageDto)
        {
            var championSummonerSpells = new ChampionSummonerSpells
            {
                ChampionId = championPageDto.Key,
                WinRate = championPageDto.SummonerSpellsWinRate,
                TotalMatches = championPageDto.SummonerSpellsTotalMatches,
            };

            await this.championSummonerSpellsRepository.AddAsync(championSummonerSpells);
            await this.championSummonerSpellsRepository.SaveChangesAsync();

            var championSummonerSpellsId = this.championSummonerSpellsRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.ChampionId == championPageDto.Key
                && x.WinRate == championPageDto.SummonerSpellsWinRate
                && x.TotalMatches == championPageDto.SummonerSpellsTotalMatches).Id;

            var dbChampionSummonerSpells = this.championSummonerSpellsRepository.All().FirstOrDefault(x => x.Id == championSummonerSpellsId);

            foreach (var spellDto in championPageDto.SummonerSpells)
            {
                var summonerSpellId = this.summonerSpellsRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(s => s.Name == spellDto).Id;

                var spellToAdd = await this.summonerSpellsRepository.GetByIdWithDeletedAsync(summonerSpellId);
                dbChampionSummonerSpells.SummonerSpells.Add(spellToAdd);

                var championSummonerSpellsSummonerSpell = new ChampionSummonerSpellsSummonerSpell
                {
                    ChampionSummonerSpellsId = championSummonerSpellsId,
                    SummonerSpellId = summonerSpellId,
                };

                await this.championSummonerSpellsSummonerSpellRepository.AddAsync(championSummonerSpellsSummonerSpell);
            }

            this.championSummonerSpellsRepository.Update(dbChampionSummonerSpells);

            await this.championSummonerSpellsSummonerSpellRepository.SaveChangesAsync();

            this.championsRepository.GetByIdWithDeletedAsync(championPageDto.Key).Result.BestSummonerSpells.Add(championSummonerSpells);
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

            this.championsRepository.GetByIdWithDeletedAsync(championPageDto.Key).Result.ChampionRoles.Add(championRole);
        }

        private async Task AddChampionAbilitiesStatistics(ChampionPageDto championPageDto)
        {
            var championAbilities = new ChampionAbilities
            {
                ChampionId = championPageDto.Key,
                WinRate = championPageDto.SkillsWinRate,
                TotalMatches = championPageDto.SkillsMatchesCount,
            };

            await this.championAbilitiesRepository.AddAsync(championAbilities);
            await this.championAbilitiesRepository.SaveChangesAsync();

            var championAbilitiesId = this.championAbilitiesRepository
                .AllAsNoTracking()
                .FirstOrDefault(x => x.ChampionId == championPageDto.Key
                && x.TotalMatches == championPageDto.SkillsMatchesCount && x.WinRate == championPageDto.SkillsWinRate).Id;

            var dbChampionAbilities = this.championAbilitiesRepository.All().FirstOrDefault(x => x.Id == championAbilitiesId);

            foreach (var abilityTypeDto in championPageDto.SkillsPriority)
            {
                var abilityId = this.baseChampionAbilitiesRepository
                    .AllAsNoTracking()
                    .FirstOrDefault(a => a.Id == championPageDto.Key + abilityTypeDto).Id;

                var spellToAdd = await this.baseChampionAbilitiesRepository.GetByIdWithDeletedAsync(abilityId);
                dbChampionAbilities.Abilities.Add(spellToAdd);

                var championAbilitiesAbility = new ChampionAbilitiesAbility
                {
                    BaseAbilityId = abilityId,
                    ChampionAbilitiesId = championAbilitiesId,
                };

                await this.championAbilitiesAbilitiesRepository.AddAsync(championAbilitiesAbility);
            }

            this.championAbilitiesRepository.Update(dbChampionAbilities);

            await this.championAbilitiesAbilitiesRepository.SaveChangesAsync();

            this.championsRepository.GetByIdWithDeletedAsync(championPageDto.Key).Result.BestAbilities.Add(championAbilities);
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

            int[] runeTypeValues = { 0, 1, 5, 0, 2, 3, 4, 2, 3 };
            int runesAddedCount = 0;

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
                        RuneType = (StatRuneType)runeTypeValues[runesAddedCount],
                        Description = currentDescription,
                        ImagePath = $"wwwroot/images/statrunes/{currentDescription.Split(" ").First()}.png",
                    });

                    runesAddedCount++;
                }

                await this.statRuneRowsRepository.AddAsync(runeRow);
            }

            await this.statRuneRowsRepository.SaveChangesAsync();
        }
    }
}
