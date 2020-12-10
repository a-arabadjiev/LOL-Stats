namespace LoLStats.Data.Models
{
    using LoLStats.Data.Common.Models;

    public class ChampionAbilitiesAbility : BaseDeletableModel<int>
    {
        public virtual ChampionAbilities ChampionAbilities { get; set; }

        public int ChampionAbilitiesId { get; set; }

        public virtual BaseAbility BaseAbility { get; set; }

        public string BaseAbilityId { get; set; }
    }
}
