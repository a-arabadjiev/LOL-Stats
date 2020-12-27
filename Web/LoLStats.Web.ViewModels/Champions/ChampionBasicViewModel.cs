namespace LoLStats.Web.ViewModels.Champions
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class ChampionBasicViewModel : IMapFrom<Champion>
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Id { get; set; }
    }
}
