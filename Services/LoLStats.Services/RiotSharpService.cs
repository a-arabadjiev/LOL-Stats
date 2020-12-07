namespace LoLStats.Services
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using LoLStats.Services.Models.RiotApiDtos;
    using RiotSharp;

    public class RiotSharpService : IRiotSharpService
    {
        private readonly RiotApi api;
        private readonly string latestVersion;

        public RiotSharpService()
        {
            this.api = RiotApi.GetDevelopmentInstance("RGAPI-46dba1f0-2bbc-4b15-95c3-75f9bab62f9b");
            this.latestVersion = this.api.StaticData.Versions.GetAllAsync().GetAwaiter().GetResult()[0];
        }

        public string[] GetAllChampionKeys()
        {
            return this.api.StaticData.Champions.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Champions.Values.Select(x => x.Key).ToArray();
        }

        public ConcurrentBag<RiotApiChampionDto> ReturnChampionsData()
        {
            throw new System.NotImplementedException();
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
