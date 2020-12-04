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
    using LoLStats.Services.Models;
    using RiotSharp;

    public class UGGScraperService : IUGGScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        private readonly RiotApi riotApi;
        private readonly string latestVersion;

        public UGGScraperService()
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
            this.riotApi = RiotApi.GetDevelopmentInstance("RGAPI-46dba1f0-2bbc-4b15-95c3-75f9bab62f9b");
            this.latestVersion = this.riotApi.StaticData.Versions.GetAllAsync().GetAwaiter().GetResult()[0];
        }

        public void PopulateDbWithChampionStatistics()
        {
            var concurrentBag = new ConcurrentBag<ChampionPageDto>();

            var championKeys = this.GetAllChampionKeys();

            Parallel.For(0, championKeys.Length, (i) =>
            {
                try
                {
                    var championPageDto = this.GetChampionStatistics(championKeys[i]);
                    concurrentBag.Add(championPageDto);
                }
                catch
                {
                }
            });
        }

        private ChampionPageDto GetChampionStatistics(string championName)
        {
            var document = this.context
                .OpenAsync($"https://u.gg/lol/champions/{championName}/build")
                .GetAwaiter()
                .GetResult();

            if (document.StatusCode == System.Net.HttpStatusCode.NotFound || document.DocumentElement.TextContent.Contains("THIS PAGEDOESN'T EXIST"))
            {
                throw new InvalidOperationException();
            }

            var championPageDto = new ChampionPageDto();

            // Lane
            var championHeaderElement = document.QuerySelector(SelectorConstants.ChampionHeader);

            string lanePattern = "(?<=for )[A-Z]{1}[a-z]+";

            string lane = Regex.Match(championHeaderElement.TextContent, lanePattern).ToString();

            championPageDto.Role = (Role)Enum.Parse(typeof(Role), lane);

            // Tier
            championPageDto.ChampionTier = championHeaderElement.TextContent[0].ToString();

            // Patch
            string patchPattern = "[0-9]+.[0-9]+";

            championPageDto.Patch = Regex.Match(championHeaderElement.TextContent, patchPattern).ToString();

            // WinRate
            var championRankingStatsElement = document.QuerySelector(SelectorConstants.ChampionRankingStatsSection);

            string winRatePattern = "[0-9.]+(?=%Win)";

            championPageDto.ChampionWinRate = double.Parse(Regex.Match(championRankingStatsElement.TextContent, winRatePattern).ToString());

            // PickRate
            string pickRatePattern = "[0-9.]+(?=%Pick)";

            championPageDto.ChampionPickRate = double.Parse(Regex.Match(championRankingStatsElement.TextContent, pickRatePattern).ToString());

            // BanRate
            string banRatePattern = "[0-9.]+(?=%Ban)";

            championPageDto.ChampionBanRate = double.Parse(Regex.Match(championRankingStatsElement.TextContent, banRatePattern).ToString());

            // MatchesCount
            string matchesCountPattern = "[0-9,]+(?=Matches)";

            championPageDto.ChampionTotalMatches = int.Parse(Regex.Match(championRankingStatsElement.TextContent, matchesCountPattern).ToString());

            // SummonerSpells
            var summonerSpellsElement = document.QuerySelector(SelectorConstants.SummonerSpellsSection);

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

            championPageDto.SummonerSpellsTotalMatches = int.Parse(Regex.Match(summonerSpellsElement.TextContent, summonersTotalMatchesPattern).ToString());

            // RuneTrees
            var runesElement = document.QuerySelector(SelectorConstants.RunesSection);

            string mainRuneTreePattern = "(?<=The Rune Tree )[A-Z][a-z]+";

            var runeTrees = Regex.Matches(runesElement.InnerHtml, mainRuneTreePattern).ToArray();

            string mainRuneTree = runeTrees[0].ToString();
            string secondaryRuneTree = runeTrees[1].ToString();

            championPageDto.MainRuneTree = (RunePath)Enum.Parse(typeof(RunePath), mainRuneTree);
            championPageDto.SecondaryRuneTree = (RunePath)Enum.Parse(typeof(RunePath), secondaryRuneTree);

            // RunesWinRate
            string runeWinRatePattern = "(?<=Build)[0-9.]+";

            championPageDto.RunesWinRate = double.Parse(Regex.Match(runesElement.TextContent, runeWinRatePattern).ToString());

            // RunesMatchesCount
            string runeMatchesCountPattern = "[0-9,]+(?= Matches)";

            championPageDto.RunesMatchesCount = int.Parse(Regex.Matches(runesElement.TextContent, runeMatchesCountPattern)[0].ToString());

            // PrimaryRuneTreeRunes
            var primaryRuneTreeElements = document.QuerySelector(SelectorConstants.PrimaryRuneTreeSection).Children.ToList();

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
            var secondaryRuneTreeElements = document.QuerySelector(SelectorConstants.SecondaryRuneTreeSection).Children.ToList();
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

            var statRuneTreeElements = document.QuerySelector(SelectorConstants.StatsRuneSection).Children.ToList();
            string statRuneNamePatter = "(?<=alt=\")[A-Za-z ]+";

            foreach (var statRuneElement in statRuneTreeElements)
            {
                foreach (var runeRowElement in statRuneElement.Children)
                {
                    foreach (var activeRuneElement in runeRowElement.Children.Where(x => x.ClassName == "shard shard-active"))
                    {
                        string runeName = Regex.Match(activeRuneElement.InnerHtml, statRuneNamePatter).ToString();
                        championPageDto.StatRunes.Add(runeName);
                    }
                }
            }

            // SkillPriority
            var skills = new List<string>();

            var skillsSectionElement = document.QuerySelector(SelectorConstants.SkillsSection);

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

            championPageDto.SkillsMatchesCount = int.Parse(Regex.Match(skillsSectionElement.InnerHtml, skillsMatchesCountPattern).ToString());

            // CounterChampions
            List<string> counterChampions = new List<string>();

            var counterChampionsSectionElement = document.QuerySelector(SelectorConstants.CounterChampionsSection);

            string bestCounterChampionPattern = "[A-Za-z &.]+(?=[0-9])";

            string bestCounterChampion = Regex.Match(counterChampionsSectionElement.TextContent, bestCounterChampionPattern).ToString();

            counterChampions.Add(bestCounterChampion);

            string counterChampionsPattern = "(?<=Matches)[A-Za-z &.]+(?=[0-9])";

            var counterChampionElements = Regex.Matches(counterChampionsSectionElement.TextContent, counterChampionsPattern).ToArray();

            foreach (var counterChamp in counterChampionElements)
            {
                championPageDto.CounterChampions.Add(counterChamp.ToString());
            }

            return championPageDto;
        }

        private string[] GetAllChampionKeys()
        {
            return this.riotApi.StaticData.Champions.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Champions.Values.Select(x => x.Key).ToArray();
        }
    }
}
