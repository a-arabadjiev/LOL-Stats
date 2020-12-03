namespace LoLStats.Common
{
    using RiotSharp;
    using RiotSharp.Misc;

    public class RiotSharpConfigured
    {
        public RiotSharpConfigured()
        {
            this.RiotApi = RiotApi.GetDevelopmentInstance("RGAPI-4101ed56-d630-43f9-bd22-f7bc85fb3d70");
            this.LatestVersion = this.RiotApi.StaticData.Versions.GetAllAsync().Result[0];
        }

        public RiotApi RiotApi { get; set; }

        public string LatestVersion { get; set; }
    }
}
