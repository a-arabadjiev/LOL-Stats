namespace LoLStats.Web.ViewModels.Champions
{

    public class ChampionRoleViewModel
    {
        public string Role { get; set; }

        public string Tier { get; set; }

        public double PickRate { get; set; }

        public double WinRate { get; set; }

        public int TotalMatches { get; set; }

        public double BanRate { get; set; }

        public string ImagePath { get; set; }
    }
}