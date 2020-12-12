namespace LoLStats.Web.ViewModels.Home
{
    using AutoMapper;
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class TopChampionForRoleViewModel : IMapFrom<ChampionRole>
    {
        public string ChampionName { get; set; }

        public string ChapmionId { get; set; }

        public string Role { get; set; }

        public string ChampionImageUrl { get; set; }

        public double WinRate { get; set; }

        public double PickRate { get; set; }

        public double BanRate { get; set; }
    }
}
