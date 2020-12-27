namespace LoLStats.Web.ViewModels.SummonerSpells
{
    using LoLStats.Data.Models;
    using LoLStats.Services.Mapping;

    public class SummonerSpellViewModel : IMapFrom<SummonerSpell>
    {
        public string Name { get; set; }

        public string Tooltip { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public double BaseCooldown { get; set; }

        public string ImageUrl { get; set; }
    }
}
