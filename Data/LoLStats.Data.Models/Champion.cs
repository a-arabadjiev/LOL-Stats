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

        public string Lore { get; set; }

        public string Key { get; set; }

        public string Partype { get; set; }

        public decimal WinRate { get; set; }

        public decimal PickRate { get; set; }

        public decimal BanRate { get; set; }

        public string Tier { get; set; }

        public bool IsFree { get; set; }

        public virtual ICollection<BaseChampionAbility> BaseAbilities { get; set; }

        public virtual ICollection<ChampionAbilities> ChampionAbilities { get; set; }

        public virtual ICollection<ChampionRole> ChampionRoles { get; set; }

        public virtual ICollection<ChampionSummonerSpells> ChampionSummonerSpells { get; set; }

        public virtual ICollection<ChampionStarterItems> ChampionStarterItems { get; set; }

        public virtual ICollection<ChampionItems> ChampionItems { get; set; }

        public virtual ICollection<ChampionRunes> ChampionRunes { get; set; }

        public virtual ICollection<Champion> CounterChampions { get; set; }
    }
}
