namespace LoLStats.Web.ViewModels.Champions
{
    using System.Collections.Generic;

    using LoLStats.Web.ViewModels.Abilities;

    public class ChampionAbilitiesViewModel
    {
        public ChampionAbilitiesViewModel()
        {
            this.Abilities = new List<BaseAbilityViewModel>();
        }

        public int TotalMatches { get; set; }

        public double WinRate { get; set; }

        public string ChampionId { get; set; }

        public ICollection<BaseAbilityViewModel> Abilities { get; set; }
    }
}