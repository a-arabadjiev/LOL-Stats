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
        private readonly IDeletableEntityRepository<AbilityPerLevel> abilitiesPerLevelRepository;
        private readonly IDeletableEntityRepository<AllyTip> allyTipsRepository;
        private readonly IDeletableEntityRepository<BaseChampionAbility> baseChampionAbilitiesRepository;
        private readonly IDeletableEntityRepository<Champion> championsRepository;
        private readonly IDeletableEntityRepository<ChampionAbilities> championAbilitiesRepository;
        private readonly IDeletableEntityRepository<ChampionItems> championItemsRepository;
        private readonly IDeletableEntityRepository<ChampionRole> championRolesRepository;
        private readonly IDeletableEntityRepository<ChampionRunes> championRunesRepository;
        private readonly IDeletableEntityRepository<ChampionStarterItems> championStarterItemsRepository;
        private readonly IDeletableEntityRepository<ChampionStats> championStatsRepository;
        private readonly IDeletableEntityRepository<ChampionSummonerSpells> championSummonerSpellsRepository;
        private readonly IDeletableEntityRepository<EnemyTip> enemyTipsRepository;
        private readonly IDeletableEntityRepository<ChampionInfo> championInfoRepository;
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        private readonly IDeletableEntityRepository<ChampionPassive> championPassivesRepository;
        private readonly IDeletableEntityRepository<RunePath> runePathsRepository;
        private readonly IDeletableEntityRepository<Rune> runesRepository;
        private readonly IDeletableEntityRepository<StatRune> statRunesRepository;
        private readonly IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository;
        private readonly IDeletableEntityRepository<Tag> tagsRepository;
        private readonly IRiotSharpService riotSharpService;
        private readonly IScraperService scraperService;

        public DbService(
            IRiotSharpService riotSharpService,
            IScraperService scraperService,
            IDeletableEntityRepository<AbilityPerLevel> abilitiesPerLevelRepository,
            IDeletableEntityRepository<AllyTip> allyTipsRepository,
            IDeletableEntityRepository<BaseChampionAbility> baseChampionAbilitiesRepository,
            IDeletableEntityRepository<Champion> championsRepository,
            IDeletableEntityRepository<ChampionAbilities> championAbilitiesRepository,
            IDeletableEntityRepository<ChampionItems> championItemsRepository,
            IDeletableEntityRepository<ChampionRole> championRolesRepository,
            IDeletableEntityRepository<ChampionRunes> championRunesRepository,
            IDeletableEntityRepository<ChampionStarterItems> championStarterItemsRepository,
            IDeletableEntityRepository<ChampionStats> championStatsRepository,
            IDeletableEntityRepository<ChampionSummonerSpells> championSummonerSpellsRepository,
            IDeletableEntityRepository<EnemyTip> enemyTipsRepository,
            IDeletableEntityRepository<ChampionInfo> championInfoRepository,
            IDeletableEntityRepository<Item> itemsRepository,
            IDeletableEntityRepository<ChampionPassive> championPassivesRepository,
            IDeletableEntityRepository<RunePath> runePathsRepository,
            IDeletableEntityRepository<Rune> runesRepository,
            IDeletableEntityRepository<StatRune> statRunesRepository,
            IDeletableEntityRepository<SummonerSpell> summonerSpellsRepository,
            IDeletableEntityRepository<Tag> tagsRepository)
        {
            this.riotSharpService = riotSharpService;
            this.scraperService = scraperService;
            this.abilitiesPerLevelRepository = abilitiesPerLevelRepository;
            this.allyTipsRepository = allyTipsRepository;
            this.baseChampionAbilitiesRepository = baseChampionAbilitiesRepository;
            this.championsRepository = championsRepository;
            this.championAbilitiesRepository = championAbilitiesRepository;
            this.championItemsRepository = championItemsRepository;
            this.championRolesRepository = championRolesRepository;
            this.championRunesRepository = championRunesRepository;
            this.championStarterItemsRepository = championStarterItemsRepository;
            this.championStatsRepository = championStatsRepository;
            this.championSummonerSpellsRepository = championSummonerSpellsRepository;
            this.enemyTipsRepository = enemyTipsRepository;
            this.championInfoRepository = championInfoRepository;
            this.itemsRepository = itemsRepository;
            this.championPassivesRepository = championPassivesRepository;
            this.runePathsRepository = runePathsRepository;
            this.runesRepository = runesRepository;
            this.statRunesRepository = statRunesRepository;
            this.summonerSpellsRepository = summonerSpellsRepository;
            this.tagsRepository = tagsRepository;
        }

        public async Task PopulateDatabaseWithData()
        {
            var championDtos = this.riotSharpService.ReturnChampionsData().OrderBy(x => x.Key).ToArray();
            var itemDtos = this.riotSharpService.ReturnChampionsData().ToArray();
            var runeDtos = this.riotSharpService.ReturnChampionsData().ToArray();
            var summonerSpellDtos = this.riotSharpService.ReturnChampionsData().ToArray();
            var championPageDtos = this.scraperService.ReturnChampionPageInfo().OrderBy(x => x.Key).ToArray();

            for (int i = 0; i < championDtos.Length; i++)
            {
                var championDto = championDtos[i];
                var championPageDto = championPageDtos[i];

                var champion = new Champion
                {
                    Name = championDto.Name,
                    Key = championDto.Key,
                    Title = championDto.Title,
                    Lore = championDto.Lore,
                    ImageUrl = championDto.ImageUrl,
                    Tier = championPageDto.ChampionTier,
                    Partype = championDto.Partype,
                    PickRate = championPageDto.ChampionPickRate,
                    WinRate = championPageDto.ChampionWinRate,
                    BanRate = championPageDto.ChampionBanRate,
                    Passive = new ChampionPassive
                    {
                        Name = championDto.Passive.Name,
                        Description = championDto.Passive.Description,
                        ImageUrl = championDto.Passive.ImageUrl,
                        ChampionId = i,
                    },
                    Info = new ChampionInfo
                    {
                        Attack = championDto.Info.Attack,
                        Defense = championDto.Info.Defense,
                        Magic = championDto.Info.Magic,
                        Difficulty = championDto.Info.Difficulty,
                        ChampionId = i,
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
                        ChampionId = i,
                    },
                    IsFree = championDto.IsFree,
                };

                foreach (var tipDto in championDto.AllyTips)
                {
                    var allyTip = new AllyTip
                    {
                        Description = tipDto.Description,
                        ChampionId = i,
                    };
                    champion.AllyTips.Add(allyTip);
                }

                foreach (var tipDto in championDto.EnemyTips)
                {
                    var enemyTip = new EnemyTip
                    {
                        Description = tipDto.Description,
                        ChampionId = i,
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
                        Description = spellDto.Description,
                        AbilityType = spellDto.AbilityType,
                        ImageUrl = spellDto.ImageUrl,
                        MaxRank = spellDto.MaxRank,
                        ChampionId = i,
                    };

                    foreach (var stat in spellDto.PerLevelStats)
                    {
                        var perLevel = new AbilityPerLevel
                        {
                            Level = stat.Level,
                            BaseChampionAbilityId = j,
                            Cooldown = stat.Cooldown,
                            Range = stat.Range,
                            Cost = stat.Cost,
                            CostsPerSecond = stat.CostsPerSecond,
                        };

                        championAbility.PerLevelStats.Add(perLevel);
                    }
                }

                var bestChampionItems = new ChampionStarterItems
                {
                    ChampionId = i,
                    PickRate = championPageDto.StartingItemsPickRate,
                    WinRate = championPageDto.StartingItemsWinRate,
                };
                foreach (var item in championPageDto.StartingItems)
                {
                    //bestChampionItems.Items.Add(item);
                }
            }
        }
    }
}
