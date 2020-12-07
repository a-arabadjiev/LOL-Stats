namespace LoLStats.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Models.RiotApiDtos;
    using RiotSharp;

    public class RiotSharpService : IRiotSharpService
    {
        private readonly RiotApi api;
        private readonly string latestVersion;
        private readonly ISanitizerService sanitizerService;

        public RiotSharpService(ISanitizerService sanitizerService)
        {
            this.api = RiotApi.GetDevelopmentInstance("RGAPI-46dba1f0-2bbc-4b15-95c3-75f9bab62f9b");
            this.latestVersion = this.api.StaticData.Versions.GetAllAsync().GetAwaiter().GetResult()[0];
            this.sanitizerService = sanitizerService;
        }

        public string[] GetAllChampionKeys()
        {
            return this.api.StaticData.Champions.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Champions.Values.Select(x => x.Key).ToArray();
        }

        public ConcurrentBag<RiotApiChampionDto> ReturnChampionsData()
        {
            var championsBag = new ConcurrentBag<RiotApiChampionDto>();

            var champions = this.api.StaticData.Champions.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Champions.Values;

            foreach (var champion in champions)
            {
                RiotApiChampionDto championDto = new RiotApiChampionDto
                {
                    Name = champion.Name,
                    Key = champion.Key,
                    Title = champion.Title,
                    Lore = champion.Lore,
                    ImageUrl = "http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + champion.Image.Group + "/" + champion.Image.Full,
                    Partype = (ResourceType)Enum.Parse(typeof(ResourceType), champion.Partype),
                    Info = new RiotApiChampionInfoDto
                    {
                        Attack = (byte)champion.Info.Attack,
                        Defense = (byte)champion.Info.Defense,
                        Magic = (byte)champion.Info.Magic,
                        Difficulty = (byte)champion.Info.Difficulty,
                    },
                    Passive = new RiotApiChampionPassiveDto
                    {
                        Name = champion.Passive.Name,
                        Description = this.sanitizerService.SanitizeString(champion.Passive.Description),
                        ImageUrl = "http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + champion.Passive.Image.Group + "/" + champion.Passive.Image.Full,
                    },
                    Stats = new RiotApiChampionStatsDto
                    {
                        Armor = champion.Stats.Armor,
                        ArmorPerLevel = champion.Stats.Armor,
                        AttackDamage = champion.Stats.Armor,
                        AttackDamagePerLevel = champion.Stats.Armor,
                        AttackRange = champion.Stats.Armor,
                        AttackSpeedOffset = champion.Stats.Armor,
                        AttackSpeedPerLevel = champion.Stats.Armor,
                        Crit = champion.Stats.Armor,
                        CritPerLevel = champion.Stats.Armor,
                        Hp = champion.Stats.Armor,
                        HpPerLevel = champion.Stats.Armor,
                        HpRegen = champion.Stats.Armor,
                        HpRegenPerLevel = champion.Stats.Armor,
                        MoveSpeed = champion.Stats.Armor,
                        Mp = champion.Stats.Armor,
                        MpPerLevel = champion.Stats.Armor,
                        MpRegen = champion.Stats.Armor,
                        MpRegenPerLevel = champion.Stats.Armor,
                        SpellBlock = champion.Stats.Armor,
                        SpellBlockPerLevel = champion.Stats.Armor,
                    },
                };

                foreach (var tip in champion.AllyTips)
                {
                    championDto.AllyTips.Add(new RiotApiChampionTipDto { Description = tip });
                }

                foreach (var tip in champion.EnemyTips)
                {
                    championDto.EnemyTips.Add(new RiotApiChampionTipDto { Description = tip });
                }

                foreach (var tag in champion.Tags)
                {
                    championDto.Tags.Add(new RiotApiChampionTagDto { Name = (TagType)Enum.Parse(typeof(TagType), tag.ToString()) });
                }

                for (int i = 0; i < champion.Spells.Count; i++)
                {
                    var currentSpell = champion.Spells[i];

                    HashSet<RiotApiAbilityPerLevelDto> abilitiyPerLevelDtos = new HashSet<RiotApiAbilityPerLevelDto>();

                    var rangeList = (dynamic)currentSpell.Range; // Cast object to dynamic object so it can become iteratable

                    // Fill abilityPerLevelDtos list
                    for (int j = 1; j <= currentSpell.Cooldowns.Count; j++)
                    {
                        var abilityPerLevelDto = new RiotApiAbilityPerLevelDto
                        {
                            Level = (byte)j,
                            Cooldown = currentSpell.Cooldowns[j],
                            Cost = currentSpell.Costs[j],
                            CostsPerSecond = currentSpell.CostType.Contains("per Second") ? true : false,
                            Range = rangeList[j],
                        };

                        abilitiyPerLevelDtos.Add(abilityPerLevelDto);
                    }

                    championDto.Spells.Add(new RiotApiSpellDto
                    {
                        Name = currentSpell.Name,
                        AbilityType = (AbilityType)i,
                        Description = this.sanitizerService.SanitizeString(currentSpell.Description),
                        ImageUrl = "http://ddragon.leagueoflegends.com/cdn/5.2.1/img/" + currentSpell.Image.Group + "/" + currentSpell.Image.Full,
                        Tooltip = currentSpell.Tooltip,
                        MaxRank = (byte)currentSpell.MaxRank,
                        PerLevelStats = abilitiyPerLevelDtos,
                    });
                }

                championsBag.Add(championDto);
            }

            return championsBag;
        }

        public ConcurrentBag<RiotApiChampionDto> ReturnItemsData()
        {
            throw new System.NotImplementedException();
        }

        public ConcurrentBag<RiotApiChampionDto> ReturnRunesData()
        {
            throw new System.NotImplementedException();
        }

        public ConcurrentBag<RiotApiChampionDto> ReturnSummonerSpellsData()
        {
            throw new System.NotImplementedException();
        }
    }
}
