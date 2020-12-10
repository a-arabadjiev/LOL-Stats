namespace LoLStats.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class Champion : BaseDeletableModel<string>
    {
        public Champion()
        {
            this.BaseAbilities = new HashSet<BaseChampionAbility>();
            this.BestAbilities = new HashSet<ChampionAbilities>();
            this.ChampionRoles = new HashSet<ChampionRole>();
            this.BestSummonerSpells = new HashSet<ChampionSummonerSpells>();
            this.BestStartingItems = new HashSet<ChampionStarterItems>();
            this.BestItems = new HashSet<ChampionItems>();
            this.BestRunes = new HashSet<ChampionRunes>();
            this.CounterChampions = new HashSet<Champion>();
            this.Tags = new HashSet<Tag>();
            this.AllyTips = new HashSet<AllyTip>();
            this.EnemyTips = new HashSet<EnemyTip>();
        }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Lore { get; set; }

        public ResourceType Partype { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFree { get; set; }

        public virtual ChampionPassive Passive { get; set; }

        [ForeignKey("Passive")]
        public int PassiveId { get; set; }

        public virtual ChampionInfo Info { get; set; }

        [ForeignKey("Info")]
        public int InfoId { get; set; }

        public virtual ChampionStats Stats { get; set; }

        [ForeignKey("Stats")]
        public int StatsId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<AllyTip> AllyTips { get; set; }

        public virtual ICollection<EnemyTip> EnemyTips { get; set; }

        public virtual ICollection<BaseChampionAbility> BaseAbilities { get; set; }

        public virtual ICollection<ChampionAbilities> BestAbilities { get; set; }

        public virtual ICollection<ChampionRole> ChampionRoles { get; set; }

        public virtual ICollection<ChampionSummonerSpells> BestSummonerSpells { get; set; }

        public virtual ICollection<ChampionStarterItems> BestStartingItems { get; set; }

        public virtual ICollection<ChampionItems> BestItems { get; set; }

        public virtual ICollection<ChampionRunes> BestRunes { get; set; }

        public virtual ICollection<Champion> CounterChampions { get; set; }
    }
}
