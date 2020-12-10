namespace LoLStats.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;
    using LoLStats.Data;
    using LoLStats.Data.Common.Repositories;
    using LoLStats.Data.Models;
    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Mapping;
    using LoLStats.Services.Models.RiotApiDtos;

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
        private readonly IDeletableEntityRepository<BaseChampionAbility> baseChampionAbilitiesRepository;
        private readonly IRiotSharpService riotSharpService;
        private readonly IScraperService scraperService;

        public DbService(
            IDeletableEntityRepository<BaseChampionAbility> baseChampionAbilitiesRepository,
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
            var championPageDtos = this.scraperService.ReturnChampionPageInfo();

            foreach (var championPageDto in championPageDtos)
            {
                var championAbilities = new ChampionAbilities
                {
                    ChampionId = championPageDto.Key,
                    WinRate = championPageDto.SkillsWinRate,
                    TotalMatches = championPageDto.SkillsMatchesCount,
                };

                foreach (var abilityTypeDto in championPageDto.SkillsPriority)
                {
                    var ability = this.baseChampionAbilitiesRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(a => a.Id == championPageDto.Key + abilityTypeDto);

                    championAbilities.Abilities.Add(ability);
                }

                await this.championAbilitiesRepository.AddAsync(championAbilities);
                await this.championAbilitiesRepository.SaveChangesAsync();

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

                var championSummonerSpells = new ChampionSummonerSpells
                {
                    ChampionId = championPageDto.Key,
                    WinRate = championPageDto.SummonerSpellsWinRate,
                    TotalMatches = championPageDto.SummonerSpellsTotalMatches,
                };

                foreach (var spellDto in championPageDto.SummonerSpells)
                {
                    var summonerSpell = this.summonerSpellsRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(s => s.Name == spellDto);

                    championSummonerSpells.SummonerSpells.Add(summonerSpell);
                }

                await this.championSummonerSpellsRepository.AddAsync(championSummonerSpells);
                await this.championSummonerSpellsRepository.SaveChangesAsync();

                var championStarterItems = new ChampionStarterItems
                {
                    ChampionId = championPageDto.Key,
                    WinRate = championPageDto.StartingItemsWinRate,
                    PickRate = championPageDto.StartingItemsPickRate,
                };

                foreach (var itemDto in championPageDto.StartingItems)
                {
                    var item = this.itemsRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(i => i.Name == itemDto);

                    championStarterItems.Items.Add(item);
                }

                await this.championStarterItemsRepository.AddAsync(championStarterItems);
                await this.championStarterItemsRepository.SaveChangesAsync();

                var championItems = new ChampionItems
                {
                    ChampionId = championPageDto.Key,
                    WinRate = (int)Math.Round(championPageDto.ItemsWinRateKvp.Values.Average()),
                };

                foreach (var itemDto in championPageDto.ItemsWinRateKvp.Keys)
                {
                    var item = this.itemsRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(i => i.Name == itemDto);

                    championItems.Items.Add(item);
                }

                await this.championItemsRepository.AddAsync(championItems);
                await this.championItemsRepository.SaveChangesAsync();

                var championRunes = new ChampionRunes
                {
                    ChampionId = championPageDto.Key,
                    WinRate = championPageDto.RunesWinRate,
                    TotalMatches = championPageDto.RunesMatchesCount,
                    MainRuneTree = championPageDto.MainRuneTree,
                    SecondaryRuneTree = championPageDto.SecondaryRuneTree,
                };

                foreach (var runeDto in championPageDto.PrimaryRunes)
                {
                    var rune = this.runesRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(r => r.Name == runeDto);

                    championRunes.Runes.Add(rune);
                }

                foreach (var runeDto in championPageDto.SecondaryRunes)
                {
                    var rune = this.runesRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(r => r.Name == runeDto);

                    championRunes.Runes.Add(rune);
                }

                for (int i = 0; i < championPageDto.StatRunes.Count; i++)
                {
                    var statRuneDto = championPageDto.StatRunes.ToArray()[i];

                    var statRune = this.statRunesRepository
                        .AllAsNoTracking()
                        .FirstOrDefault(r => r.Row.Type == (StatRuneTreeType)i && r.Type == statRuneDto);

                    championRunes.StatRunes.Add(statRune);
                }

                await this.championRunesRepository.AddAsync(championRunes);
                await this.championRunesRepository.SaveChangesAsync();
            }
        }

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

                    var championAbility = new BaseChampionAbility
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
