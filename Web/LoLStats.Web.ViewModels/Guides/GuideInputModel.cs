namespace LoLStats.Web.ViewModels.Guides
{
    using LoLStats.Web.ViewModels.Champions;
    using LoLStats.Web.ViewModels.Roles;
    using LoLStats.Web.ViewModels.SummonerSpells;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GuideInputModel
    {
        public GuideInputModel()
        {
            this.Roles = new List<RoleViewModel>();

            this.StartingItems = new List<string>();
            this.MainItems = new List<string>();
            this.AllChampions = new List<ChampionBasicViewModel>();
            this.AllSummonerSpells = new List<SummonerSpellViewModel>();
        }

        // View
        public IEnumerable<RoleViewModel> Roles { get; set; }

        public IEnumerable<ChampionBasicViewModel> AllChampions { get; set; }

        public IEnumerable<SummonerSpellViewModel> AllSummonerSpells { get; set; }

        // Input
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string GuideTitle { get; set; }

        [MinLength(30)]
        [MaxLength(500)]
        public string GuideDescription { get; set; }

        public string GuideCategory { get; set; }

        [Required]
        public string ChampionName { get; set; }

        [Required]
        public string ChampionRole { get; set; }

        [Required]
        public string SummonerSpellA { get; set; }

        [Required]
        public string SummonerSpellB { get; set; }

        public string SummonerSpellsNotes { get; set; }

        [Required]
        public ICollection<string> StartingItems { get; set; }

        public string StartingItemsNotes { get; set; }

        [Required]
        public ICollection<string> MainItems { get; set; }

        public string MainItemsNotes { get; set; }

        [Required]
        public ICollection<string> SkillPriority { get; set; }

        public string SkillPriorityNotes { get; set; }

        [Required]
        public ICollection<string> PrimaryRunes { get; set; }

        [Required]
        public ICollection<string> SecondaryRunes { get; set; }

        [Required]
        public ICollection<string> StatRunes { get; set; }

        public string RunesNotes { get; set; }

        public ICollection<string> CounterChampions { get; set; }

        public ICollection<string> SynergyChampions { get; set; }
    }
}
