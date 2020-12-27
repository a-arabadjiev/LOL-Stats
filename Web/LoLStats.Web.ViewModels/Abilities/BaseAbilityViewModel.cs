namespace LoLStats.Web.ViewModels.Abilities
{
    using System.Collections.Generic;

    public class BaseAbilityViewModel
    {
        public BaseAbilityViewModel()
        {
            this.PerLevelStats = new List<PerLevelStatViewModel>();
        }

        public string AbilityType { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte MaxRank { get; set; }

        public bool IsFirst { get; set; }

        public ICollection<PerLevelStatViewModel> PerLevelStats { get; set; }
    }
}
