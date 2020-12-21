namespace LoLStats.Web.Controllers
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using LoLStats.Services;
    using LoLStats.Services.Data;
    using LoLStats.Web.ViewModels;
    using LoLStats.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IScraperService scraperService;
        private readonly IRiotSharpService riotSharpService;
        private readonly IDbService dbService;
        private readonly IHomeService homeService;

        public HomeController(IScraperService scraperService, IRiotSharpService riotSharpService, IDbService dbService, IHomeService homeService)
        {
            this.scraperService = scraperService;
            this.riotSharpService = riotSharpService;
            this.dbService = dbService;
            this.homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel
            {
                BaseData = this.homeService.GetBaseGameCounts(),
                TopChampionsForRole = this.homeService.GetTopChampionsForEachRole(),
            };

            return this.View(homeViewModel);

            // return this.RedirectToAction(nameof(this.Privacy));
        }

        public async Task<IActionResult> Privacy()
        {
            // Testing
            // await this.dbService.AddBaseGameData();
            // await this.dbService.AddChampionStatisticsData();

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
