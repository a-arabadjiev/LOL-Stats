namespace LoLStats.Services.Models.RiotApiDtos
{
    using LoLStats.Data.Models.Enums;

    public class RiotApiRuneDto
    {
        public string Name { get; set; }

        public bool IsKeystone { get; set; }

        public string Description { get; set; }

        public RunePath RunePath { get; set; }

        public string ImageUrl { get; set; }
    }
}
