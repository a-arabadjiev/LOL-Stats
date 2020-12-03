namespace LoLStats.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
<<<<<<< HEAD

=======
>>>>>>> a01cd5d5981490eeaa28d145596bed50a165ad26
    using LoLStats.Common;
    using LoLStats.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    using RiotSharp;

    public class HomeController : BaseController
    {
        private readonly RiotSharpConfigured riotSharp;

        public HomeController(RiotSharpConfigured riotSharp)
        {
            this.riotSharp = riotSharp;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            var championsList = this.riotSharp.RiotApi.StaticData.Champions.GetAllAsync(this.riotSharp.LatestVersion).Result.Champions.Values;

            foreach (var champion in championsList)
            {
                Console.WriteLine(champion.);
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
