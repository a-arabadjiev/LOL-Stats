namespace LoLStats.Services.Models.ScraperDtos
{
    public class CounterChampionDto
    {
        public string Name { get; set; }

        public double WinRate { get; set; }

        public int TotalMatches { get; set; }
    }
}
