namespace LoLStats.Web.ViewModels.Champions
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class ChampionInListViewModel : IMapFrom<Champion>
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }
    }
}
