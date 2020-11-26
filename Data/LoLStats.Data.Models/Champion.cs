namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;

    public class Champion : BaseDeletableModel<int>
    {
        public Champion()
        {
            this.BaseAbilities = new HashSet<BaseChampionAbility>();
            this.ChampionAbilities = new HashSet<ChampionAbilities>();
            this.ChampionRoles = new HashSet<ChampionRole>();
            this.ChampionSummonerSpells = new HashSet<ChampionSummonerSpells>();
            this.ChampionStarterItems = new HashSet<ChampionStarterItems>();
            this.ChampionItems = new HashSet<ChampionItems>();
            this.ChampionRunes = new HashSet<ChampionRunes>();
        }

        public string Name { get; set; }

        public decimal WinRate { get; set; }

        public decimal PickRate { get; set; }

        public decimal BanRate { get; set; }

        public string ChampionTier { get; set; }

        public bool IsFree { get; set; }

        public ICollection<BaseChampionAbility> BaseAbilities { get; set; }

        public ICollection<ChampionAbilities> ChampionAbilities { get; set; }

        public ICollection<ChampionRole> ChampionRoles { get; set; }

        public ICollection<ChampionSummonerSpells> ChampionSummonerSpells { get; set; }

        public ICollection<ChampionStarterItems> ChampionStarterItems { get; set; }

        public ICollection<ChampionItems> ChampionItems { get; set; }

        public ICollection<ChampionRunes> ChampionRunes { get; set; }
    }
}
