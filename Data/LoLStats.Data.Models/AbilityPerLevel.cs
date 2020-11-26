namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models.Enums;

    public class AbilityPerLevel : BaseDeletableModel<int>
    {
        public int BaseChampionAbilityId { get; set; }

        public BaseChampionAbility Ability { get; set; }

        public int Level { get; set; }

        public int Cooldown { get; set; }

        public int Cost { get; set; }

        public bool CostsPerSecond { get; set; }

        public bool GeneratesResource { get; set; }

        public int Range { get; set; }
    }
}
