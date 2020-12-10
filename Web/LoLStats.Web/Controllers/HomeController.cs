namespace LoLStats.Web.Controllers
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using LoLStats.Common;
    using LoLStats.Services;
    using LoLStats.Services.Models.RiotApiDtos;
    using LoLStats.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IScraperService scraperService;
        private readonly IRiotSharpService riotSharpService;
        private readonly IDbService dbService;

        public HomeController(IScraperService scraperService, IRiotSharpService riotSharpService, IDbService dbService)
        {
            this.scraperService = scraperService;
            this.riotSharpService = riotSharpService;
            this.dbService = dbService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public async Task<IActionResult> Privacy()
        {
            // Testing
            await this.dbService.AddChampionStatisticsData();

            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
