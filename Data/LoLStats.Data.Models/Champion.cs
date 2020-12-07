namespace LoLStats.Data.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

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
            this.CounterChampions = new HashSet<Champion>();
            this.Tags = new HashSet<Tag>();
            this.AllyTips = new HashSet<Tip>();
            this.EnemyTips = new HashSet<Tip>();
        }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }

        public string Lore { get; set; }

        public ResourceType Partype { get; set; }

        public double WinRate { get; set; }

        public double PickRate { get; set; }

        public double BanRate { get; set; }

        public string ImageUrl { get; set; }

        public string Tier { get; set; }

        public bool IsFree { get; set; }

        public virtual Passive Passive { get; set; }

        public virtual Info Info { get; set; }

        public virtual ChampionStats ChampionStats { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Tip> AllyTips { get; set; }

        public virtual ICollection<Tip> EnemyTips { get; set; }

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
