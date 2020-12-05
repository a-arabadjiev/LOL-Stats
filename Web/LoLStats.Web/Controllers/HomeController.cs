namespace LoLStats.Web.Controllers
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using LoLStats.Common;
    using LoLStats.Services;
    using LoLStats.Services.Models;
    using LoLStats.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IScraperService scraperService;

        public HomeController(IScraperService scraperService)
        {
            this.scraperService = scraperService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            ConcurrentBag<ChampionPageDto> championData = this.scraperService.ReturnChampionPageInfo();

            foreach (var data in championData)
            {
            }

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
