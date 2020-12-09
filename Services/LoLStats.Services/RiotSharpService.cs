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
            this.api = RiotApi.GetDevelopmentInstance("RGAPI-53a0689c-15c9-442a-b3e1-9b514fd0dec9");
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


            var freeToPlayChampionIds = this.api.Champion.GetChampionRotationAsync(RiotSharp.Misc.Region.Euw).GetAwaiter().GetResult().FreeChampionIds;

            var champions = this.api.StaticData.Champions.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Champions.Values;

            foreach (var champion in champions)
            {
                RiotApiChampionDto championDto = new RiotApiChampionDto
                {
                    Name = champion.Name,
                    IsFree = freeToPlayChampionIds.Contains(champion.Id),
                    Id = champion.Key,
                    Title = champion.Title,
                    Lore = champion.Lore,
                    ImageUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.latestVersion}/img/" + champion.Image.Group + "/" + champion.Image.Full,
                    Partype = (ResourceType)Enum.Parse(typeof(ResourceType), champion.Partype.Replace(" ", string.Empty)),
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
                        ImageUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.latestVersion}/img/" + champion.Passive.Image.Group + "/" + champion.Passive.Image.Full,
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

                    var rangeList = (dynamic)currentSpell.Range; // Cast object to dynamic so it can become iterable

                    // Fill abilityPerLevelDtos list
                    for (int j = 0; j < currentSpell.Cooldowns.Count; j++)
                    {
                        var abilityPerLevelDto = new RiotApiAbilityPerLevelDto
                        {
                            Level = (byte)(j + 1),
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
                        Id = championDto.Id + ((AbilityType)i).ToString(),
                        Description = this.sanitizerService.SanitizeString(currentSpell.Description),
                        ImageUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.latestVersion}/img/" + currentSpell.Image.Group + "/" + currentSpell.Image.Full,
                        Tooltip = currentSpell.Tooltip,
                        MaxRank = (byte)currentSpell.MaxRank,
                        PerLevelStats = abilitiyPerLevelDtos,
                    });
                }

                championsBag.Add(championDto);
            }

            return championsBag;
        }

        public ConcurrentBag<RiotApiItemDto> ReturnItemsData()
        {
            var itemsBag = new ConcurrentBag<RiotApiItemDto>();

            var items = this.api.StaticData.Items.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Items.Values;

            foreach (var item in items)
            {
                RiotApiItemDto itemDto = new RiotApiItemDto
                {
                    Name = item.Name,
                    Description = this.sanitizerService.SanitizeString(item.Description),
                    Consumable = item.Consumed,
                    Depth = (byte)item.Depth,
                    HideFromAll = item.HideFromAll,
                    ImageUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.latestVersion}/img/" + item.Image.Group + "/" + item.Image.Full,
                    FullCost = item.Gold.TotalPrice,
                    IndividualCost = item.Gold.BasePrice,
                    SellingCost = item.Gold.SellingPrice,
                };

                itemsBag.Add(itemDto);
            }

            return itemsBag;
        }

        public ConcurrentBag<RiotApiRunePathDto> ReturnRunesData()
        {
            var runePathsBag = new ConcurrentBag<RiotApiRunePathDto>();

            var runes = this.api.StaticData.ReforgedRunes.GetAllAsync(this.latestVersion).GetAwaiter().GetResult();

            var runesBag = new ConcurrentBag<RiotApiRuneDto>();

            foreach (var runeTree in runes)
            {
                for (int i = 0; i < runeTree.Slots.Count; i++)
                {
                    var runeTreeSlots = runeTree.Slots;

                    foreach (var rune in runeTreeSlots[i].Runes)
                    {
                        RiotApiRuneDto runeDto = new RiotApiRuneDto
                        {
                            Name = rune.Name,
                            RunePath = (RunePathType)Enum.Parse(typeof(RunePathType), runeTree.Name),
                            ShortDescription = this.sanitizerService.SanitizeString(rune.ShortDescription),
                            LongDescription = this.sanitizerService.SanitizeString(rune.LongDescription),
                            ImageUrl = "https://ddragon.canisback.com/img/" + rune.Icon,
                            IsKeystone = i == 0 ? true : false,
                        };

                        runesBag.Add(runeDto);
                    }
                }

                RiotApiRunePathDto runePathDto = new RiotApiRunePathDto
                {
                    Name = (RunePathType)Enum.Parse(typeof(RunePathType), runeTree.Name),
                    Id = runeTree.Name,
                    ImageUrl = "https://ddragon.canisback.com/img/" + runeTree.Icon,
                    RuneDtos = runesBag.ToHashSet(),
                };

                runePathsBag.Add(runePathDto);
                runesBag.Clear();
            }

            return runePathsBag;
        }

        public ConcurrentBag<RiotApiSummonerSpellDto> ReturnSummonerSpellsData()
        {
            var summonerSpellsBag = new ConcurrentBag<RiotApiSummonerSpellDto>();

            var summonerSpells = this.api.StaticData.SummonerSpells.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().SummonerSpells.Values;

            foreach (var spell in summonerSpells)
            {
                RiotApiSummonerSpellDto summonerSpell = new RiotApiSummonerSpellDto
                {
                    Name = spell.Name,
                    Key = spell.Key,
                    Description = this.sanitizerService.SanitizeString(spell.Description),
                    Tooltip = spell.Tooltip,
                    ImageUrl = $"http://ddragon.leagueoflegends.com/cdn/{this.latestVersion}/img/" + spell.Image.Group + "/" + spell.Image.Full,
                    BaseCooldown = spell.Cooldowns[0],
                };

                summonerSpellsBag.Add(summonerSpell);
            }

            return summonerSpellsBag;
        }
    }
}
