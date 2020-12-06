namespace LoLStats.Services.Models
{
    using System.Collections.Generic;

    using LoLStats.Data.Models;
    using LoLStats.Data.Models.Enums;

    public class RiotApiDataDto
    {
        public string ChampionName { get; set; }

        public string ChampionKey { get; set; }

        public string ChampionTitle { get; set; }

        public ICollection<Tip> ChampionAllyTips { get; set; }

        public ICollection<Tip> ChampionEnemyTips { get; set; }

        public Image ChampionImage { get; set; }

        public Info ChampionInfo { get; set; }

        public string ChampionLore { get; set; }

        public ResourceType ChampionPartype { get; set; }

        public Passive ChampionPassive { get; set; }

        public ChampionStats ChampionStats { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public ICollection<Spells> MyProperty { get; set; }
    }
}
