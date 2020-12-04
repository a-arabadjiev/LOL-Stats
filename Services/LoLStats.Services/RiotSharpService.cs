namespace LoLStats.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Threading.Tasks;

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

        public List<string> GetAllChampionKeys()
        {
            return this.api.StaticData.Champions.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Champions.Values.Select(x => x.Key).ToList();
        }

        public async Task PopulateDbWithBaseGameData()
        {
            var champions = this.api.StaticData.Champions.GetAllAsync(this.latestVersion).GetAwaiter().GetResult().Champions.Values;
        }
    }
}
