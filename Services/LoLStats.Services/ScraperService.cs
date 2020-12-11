namespace LoLStats.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using AngleSharp;
    using LoLStats.Data.Models.Enums;
    using LoLStats.Services.Models.ScraperDtos;
    using RiotSharp;

    public class ScraperService : IScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        private readonly IRiotSharpService riotSharpService;

        public ScraperService(IRiotSharpService riotSharpService)
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
            this.riotSharpService = riotSharpService;
        }

        public ConcurrentBag<ChampionPageDto> ReturnChampionPageInfo()
        {
            var concurrentBag = new ConcurrentBag<ChampionPageDto>();

            var championKeys = this.riotSharpService.GetAllChampionKeys().Where(c => c != "Rell").ToArray();

            Parallel.For(0, championKeys.Length, (i) =>
            {
                var championPageDto = this.GetChampionStatistics(championKeys[i]);
                concurrentBag.Add(championPageDto);
            });

            return concurrentBag;
        }

        private ChampionPageDto GetChampionStatistics(string championName)
        {
            var uggDocument = this.context
                .OpenAsync($"https://u.gg/lol/champions/{championName}/build")
                .GetAwaiter()
                .GetResult();

            if (uggDocument.StatusCode == System.Net.HttpStatusCode.NotFound || uggDocument.DocumentElement.TextContent.Contains("THIS PAGEDOESN'T EXIST"))
            {
                throw new InvalidOperationException();
            }

            var championPageDto = new ChampionPageDto();

            championPageDto.Key = championName;

            // U.GG Scraping
            // Lane
            var championHeaderElement = uggDocument.QuerySelector(SelectorConstants.ChampionHeader);

            string lanePattern = "(?<=for )[A-Za-z]+(?=,)";

            string lane = Regex.Match(championHeaderElement.TextContent, lanePattern).ToString();

            championPageDto.Role = (RoleType)Enum.Parse(typeof(RoleType), lane);

            // Tier
            championPageDto.ChampionTier = championHeaderElement.TextContent[0].ToString(); // TODO: Make work with S+ tier

            // Patch
            string patchPattern = "[0-9]+.[0-9]+";

            championPageDto.Patch = Regex.Match(championHeaderElement.TextContent, patchPattern).ToString();

            // WinRate
            var championRankingStatsElement = uggDocument.QuerySelector(SelectorConstants.ChampionRankingStatsSection);

            string winRatePattern = "[0-9.]+(?=%Win)";

            championPageDto.ChampionWinRate = double.TryParse(Regex.Match(championRankingStatsElement.TextContent, winRatePattern).ToString(), out double resultWinRate)
                ? double.Parse(Regex.Match(championRankingStatsElement.TextContent, winRatePattern).ToString()) : 0;

            // PickRate
            string pickRatePattern = "[0-9.]+(?=%Pick)";

            championPageDto.ChampionPickRate = double.TryParse(Regex.Match(championRankingStatsElement.TextContent, pickRatePattern).ToString(), out double resultPickRate)
                ? double.Parse(Regex.Match(championRankingStatsElement.TextContent, pickRatePattern).ToString()) : 0;

            // BanRate
            string banRatePattern = "[0-9.]+(?=%Ban)";

            championPageDto.ChampionBanRate = double.TryParse(Regex.Match(championRankingStatsElement.TextContent, banRatePattern).ToString(), out double resultBanRate)
                ? double.Parse(Regex.Match(championRankingStatsElement.TextContent, banRatePattern).ToString()) : 0;

            // MatchesCount
            string matchesCountPattern = "[0-9,]+(?=Matches)";

            championPageDto.ChampionTotalMatches = int.Parse(Regex.Match(championRankingStatsElement.TextContent, matchesCountPattern).ToString().Replace(",", string.Empty));

            // SummonerSpells
            var summonerSpellsElement = uggDocument.QuerySelector(SelectorConstants.SummonerSpellsSection);

            string summonerSpellsPattern = "(?<=Summoner Spell )[A-Za-z]+";

            var summonerSpells = Regex.Matches(summonerSpellsElement.InnerHtml, summonerSpellsPattern).ToArray();

            string summonerSpellD = summonerSpells[0].ToString();
            string summonerSpellF = summonerSpells[1].ToString();

            championPageDto.SummonerSpells.Add(summonerSpellD);
            championPageDto.SummonerSpells.Add(summonerSpellF);

            // SummonerSpellsWinRate
            string summonersWinRatePattern = "[0-9.]+(?=% WR)";

            championPageDto.SummonerSpellsWinRate = double.Parse(Regex.Match(summonerSpellsElement.TextContent, summonersWinRatePattern).ToString());

            // SummonerSpellsTotalMatches
            string summonersTotalMatchesPattern = "[0-9,]+(?= Matches)";

            championPageDto.SummonerSpellsTotalMatches = int.Parse(Regex.Match(summonerSpellsElement.TextContent, summonersTotalMatchesPattern).ToString().Replace(",", string.Empty));

            // RuneTrees
            var runesElement = uggDocument.QuerySelector(SelectorConstants.RunesSection);

            string mainRuneTreePattern = "(?<=The Rune Tree )[A-Z][a-z]+";

            var runeTrees = Regex.Matches(runesElement.InnerHtml, mainRuneTreePattern).ToArray();

            string mainRuneTree = runeTrees[0].ToString();
            string secondaryRuneTree = runeTrees[1].ToString();

            championPageDto.MainRuneTree = (RuneTreeType)Enum.Parse(typeof(RuneTreeType), mainRuneTree);
            championPageDto.SecondaryRuneTree = (RuneTreeType)Enum.Parse(typeof(RuneTreeType), secondaryRuneTree);

            // RunesWinRate
            string runeWinRatePattern = "(?<=Build)[0-9.]+";

            championPageDto.RunesWinRate = double.Parse(Regex.Match(runesElement.TextContent, runeWinRatePattern).ToString());

            // RunesMatchesCount
            string runeMatchesCountPattern = "[0-9,]+(?= Matches)";

            championPageDto.RunesMatchesCount = int.Parse(Regex.Matches(runesElement.TextContent, runeMatchesCountPattern)[0].ToString().Replace(",", string.Empty));

            // PrimaryRuneTreeRunes
            var primaryRuneTreeElements = uggDocument.QuerySelector(SelectorConstants.PrimaryRuneTreeSection).Children.ToList();

            primaryRuneTreeElements.RemoveAt(0);  // removes unnecesary div element

            string runeNamePattern = "(?<=The Rune |The Keystone )[A-Za-z :]+";

            foreach (var primaryRuneTreeElement in primaryRuneTreeElements)
            {
                foreach (var runeRowElement in primaryRuneTreeElement.Children)
                {
                    foreach (var activeRuneElement in runeRowElement.Children.Where(x => x.ClassName == "perk perk-active" || x.ClassName == "perk keystone perk-active"))
                    {
                        string runeName = Regex.Match(activeRuneElement.InnerHtml, runeNamePattern).ToString();
                        championPageDto.PrimaryRunes.Add(runeName);
                    }
                }
            }

            // SecondaryRuneTreeRunes
            var secondaryRuneTreeElements = uggDocument.QuerySelector(SelectorConstants.SecondaryRuneTreeSection).Children.ToList();
            secondaryRuneTreeElements.RemoveAt(0); // removes unnecesary div element

            foreach (var secondaryRuneTreeElement in secondaryRuneTreeElements)
            {
                foreach (var runeRowElement in secondaryRuneTreeElement.Children)
                {
                    foreach (var activeRuneElement in runeRowElement.Children.Where(x => x.ClassName == "perk perk-active"))
                    {
                        string runeName = Regex.Match(activeRuneElement.InnerHtml, runeNamePattern).ToString();
                        championPageDto.SecondaryRunes.Add(runeName);
                    }
                }
            }

            // StatRunes
            var statRunes = new List<string>();

            var statRuneTreeElements = uggDocument.QuerySelector(SelectorConstants.StatsRuneSection).Children.ToList();
            string statRuneNamePatter = "(?<=alt=\")[A-Za-z ]+";

            foreach (var statRuneElement in statRuneTreeElements)
            {
                foreach (var runeRowElement in statRuneElement.Children)
                {
                    foreach (var activeRuneElement in runeRowElement.Children.Where(x => x.ClassName == "shard shard-active"))
                    {
                        string[] statRuneValues = { "Adaptive", "Attack", "Armor", "Magic", "Health", "CDR" };

                        string runeDescription = Regex.Match(activeRuneElement.InnerHtml, statRuneNamePatter).ToString();

                        string[] descriptionWords = runeDescription.Split(" ");

                        for (int i = 0; i < statRuneValues.Length; i++)
                        {
                            string value = statRuneValues[i];

                            if (descriptionWords.Contains(value))
                            {
                                championPageDto.StatRunes.Add((StatRuneType)i);
                            }
                        }
                    }
                }
            }

            // SkillPriority
            var skills = new List<string>();

            var skillsSectionElement = uggDocument.QuerySelector(SelectorConstants.SkillsSection);

            string skillsPattern = "[A-Z]{1}(?=:)";

            var skillElements = Regex.Matches(skillsSectionElement.InnerHtml, skillsPattern).ToArray();

            foreach (var skill in skillElements)
            {
                championPageDto.SkillsPriority.Add(skill.ToString());
            }

            // SkillsWinRate
            string skillsWinRatioPattern = "[0-9.]+(?=%)";

            championPageDto.SkillsWinRate = double.Parse(Regex.Match(skillsSectionElement.InnerHtml, skillsWinRatioPattern).ToString());

            // SkillsMatchesCount
            string skillsMatchesCountPattern = "[0-9,]+(?= Matches)";

            championPageDto.SkillsMatchesCount = int.Parse(Regex.Match(skillsSectionElement.InnerHtml, skillsMatchesCountPattern).ToString().Replace(",", string.Empty));

            // CounterChampions
            List<string> counterChampions = new List<string>();

            var counterChampionsSectionElement = uggDocument.QuerySelector(SelectorConstants.CounterChampionsSection);

            string bestCounterChampionPattern = "[A-Za-z &.]+(?=[0-9])";

            string bestCounterChampion = Regex.Match(counterChampionsSectionElement.TextContent, bestCounterChampionPattern).ToString();

            counterChampions.Add(bestCounterChampion);

            string counterChampionsPattern = "(?<=Matches)[A-Za-z &.]+(?=[0-9])";

            var counterChampionElements = Regex.Matches(counterChampionsSectionElement.TextContent, counterChampionsPattern).ToArray();

            foreach (var counterChamp in counterChampionElements)
            {
                championPageDto.CounterChampions.Add(counterChamp.ToString());
            }

            // Meta.src Scraping
            // StartingItems
            var metaSrcDocument = this.context
                .OpenAsync($"https://www.metasrc.com/5v5/kr/champion/{championName}/{lane}")
                .GetAwaiter()
                .GetResult();

            // Invalid Champion Page
            if (metaSrcDocument.DocumentElement.TextContent.Contains("May the METAcat guide you!"))
            {
                throw new InvalidOperationException();
            }

            var startingItemElements = metaSrcDocument.QuerySelector(SelectorConstants.StartingItemsDiv).Children;

            string startingItemPattern = "(?<=alt=\")[A-Za-z ']+(?=\"><)";

            foreach (var itemElement in startingItemElements)
            {
                string item = Regex.Match(itemElement.InnerHtml, startingItemPattern).ToString();
                championPageDto.StartingItems.Add(item);
            }

            // StartingItemsWin&PickRate
            var startingItemsSectionElement = metaSrcDocument.QuerySelector(SelectorConstants.StartingItemsSection);

            string startingItemsRatesPattern = @"(?<=<span>)[0-9]+(?=%</span>)";

            var startingItemRates = Regex.Matches(startingItemsSectionElement.InnerHtml, startingItemsRatesPattern).ToArray();

            championPageDto.StartingItemsWinRate = int.Parse(startingItemRates[0].ToString());
            championPageDto.StartingItemsPickRate = int.Parse(startingItemRates[1].ToString());

            // MainItems
            var mainItemsSectionElements = metaSrcDocument.QuerySelector(SelectorConstants.MainItemsSection).Children;

            string mainItemPattern = "[A-Za-z ']+(?=[0-9]+ [0-9]+)";
            string mainItemWinRatePattern = @"(?<=>)[0-9]+(?=%<\/div>)";

            foreach (var itemElement in mainItemsSectionElements)
            {
                string item = Regex.Match(itemElement.TextContent, mainItemPattern).ToString();
                string winRate = Regex.Match(itemElement.InnerHtml, mainItemWinRatePattern).ToString();

                championPageDto.ItemsWinRateKvp[item] = int.Parse(winRate);
            }

            return championPageDto;
        }
    }
}
