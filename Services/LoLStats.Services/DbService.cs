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
        private readonly IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository;
        private readonly IDeletableEntityRepository<StatRuneRow> statRuneRowsRepository;
        private readonly IRiotSharpService riotSharpService;
        private readonly IScraperService scraperService;

        public DbService(
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
            IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository,
            IDeletableEntityRepository<StatRuneRow> statRuneRowsRepository)
        {
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
            this.summonerSpellsRepository = summonerSpellsRepository;
            this.statRuneRowsRepository = statRuneRowsRepository;
        }

        public async Task AddBaseGameData()
        {
            var championDtos = this.riotSharpService.ReturnChampionsData().OrderBy(x => x.Id).ToArray();
            var itemDtos = this.riotSharpService.ReturnItemsData().ToArray();
            var runeTreeDtos = this.riotSharpService.ReturnRunesData().ToArray();
            var summonerSpellDtos = this.riotSharpService.ReturnSummonerSpellsData().ToArray();

            // Add Champions
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

            // Add Items
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

            // Add Summoner Spells
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

            // Add Runes
            foreach (var runeTreeDto in runeTreeDtos)
            {
                var runeTree = new RunePath
                {
                    Name = runeTreeDto.Name,
                    ImageUrl = runeTreeDto.ImageUrl,
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
                        RunePathId = runeTree.Name.ToString(),
                    };

                    runeTree.Runes.Add(rune);
                }

                await this.runePathsRepository.AddAsync(runeTree);
            }

            await this.runePathsRepository.SaveChangesAsync();

            // Add StatRunes
            string[] offenseRuneValues = { "Adaptive Force +9", "+9% Attack Speed", "Ability Haste +8 (Based on level)" };
            string[] flexRuneValues = { "Adaptive Force +9", "+6 Armor", "+8 Magic Resist" };
            string[] defenseRuneValues = { "+15-90 Health (Based on level)", "+6 Armor", "+8 Magic Resist" };

            string[][] valueRows = { offenseRuneValues, flexRuneValues, defenseRuneValues };

            for (int i = 0; i < 3; i++)
            {
                var runeRow = new StatRuneRow
                {
                    Type = (StatRuneType)i,
                    Id = ((StatRuneType)i).ToString(),
                };
                for (int j = 0; j < 3; j++)
                {
                    runeRow.Runes.Add(new StatRune
                    {
                        RowId = runeRow.Type.ToString(),
                        Description = valueRows[i][j],
                    });
                }

                await this.statRuneRowsRepository.AddAsync(runeRow);
            }

            await this.statRuneRowsRepository.SaveChangesAsync();
        }
    }
}
