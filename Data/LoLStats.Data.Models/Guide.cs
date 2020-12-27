namespace LoLStats.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LoLStats.Data.Common.Models;

    public class Guide : BaseDeletableModel<int>
    {
        public Guide()
        {
            this.SummonerSpells = new HashSet<SummonerSpell>();
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public virtual ChampionRole Role { get; set; }

        public string RoleId { get; set; }

        public virtual Champion Champion { get; set; }

        public string ChampionId { get; set; }

        public ICollection<SummonerSpell> SummonerSpells { get; set; }

        public string SummonerSpellsNotes { get; set; }

        public ICollection<Item> StartingItems { get; set; }

        public string StartingItemsNotes { get; set; }

        public ICollection<Item> MainItems { get; set; }

        public string MainItemsNotes { get; set; }

        public ICollection<BaseAbility> SkillPriority { get; set; }

        public string SkillPriorityNotes { get; set; }

        public ICollection<Rune> PrimaryRunes { get; set; }

        public ICollection<Rune> SecondaryRunes { get; set; }

        public ICollection<StatRune> StatRunes { get; set; }

        public string RunesNotes { get; set; }

        public ICollection<Champion> CounterChampions { get; set; }

        public ICollection<Champion> SynergyChampions { get; set; }
    }
}
