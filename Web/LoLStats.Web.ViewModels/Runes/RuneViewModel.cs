namespace LoLStats.Web.ViewModels.Runes
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class RuneViewModel : IMapFrom<Rune>
    {
        public string Name { get; set; }

        public bool IsKeystone { get; set; }

        public string ShortDescription { get; set; }

        public int Count { get; set; }

        public int Row { get; set; }

        public string ImageUrl { get; set; }

        public string RunePath { get; set; }

        public bool IsActive { get; set; }
    }
}
