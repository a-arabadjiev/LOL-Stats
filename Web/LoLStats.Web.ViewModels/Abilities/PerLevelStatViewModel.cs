namespace LoLStats.Web.ViewModels.Abilities
{
    public class PerLevelStatViewModel
    {
        public string BaseChampionAbilityId { get; set; }

        public byte Level { get; set; }

        public double Cooldown { get; set; }

        public double Cost { get; set; }

        public bool CostsPerSecond { get; set; }

        public double Range { get; set; }
    }
}
