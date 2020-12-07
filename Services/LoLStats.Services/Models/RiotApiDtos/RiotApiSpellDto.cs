namespace LoLStats.Services.Models.RiotApiDtos
{
    using System.Collections.Generic;

    using LoLStats.Data.Models;

    public class RiotApiSpellDto
    {
        public RiotApiSpellDto()
        {
            this.PerLevelStats = new HashSet<RiotApiAbilityPerLevelDto>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public RiotApiImage Image { get; set; }

        public string Tooltip { get; set; }

        public byte MaxRank { get; set; }

        public ICollection<RiotApiAbilityPerLevelDto> PerLevelStats { get; set; }
    }
}
