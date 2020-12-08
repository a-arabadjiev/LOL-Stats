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

        public HomeController(IScraperService scraperService, IRiotSharpService riotSharpService)
        {
            this.scraperService = scraperService;
            this.riotSharpService = riotSharpService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            // Testing
            var championsData = this.riotSharpService.ReturnChampionsData();
            var itemsData = this.riotSharpService.ReturnItemsData();
            var runesData = this.riotSharpService.ReturnRunesData();
            var summonerSpellsData = this.riotSharpService.ReturnSummonerSpellsData();

            foreach (var item in itemsData)
            {
            }

            foreach (var runePath in runesData)
            {
            }

            foreach (var summonerSpell in summonerSpellsData)
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
