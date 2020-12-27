namespace LoLStats.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LoLStats.Services.Data;
    using LoLStats.Web.ViewModels.Champions;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : BaseController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public IActionResult ReturnChampions(string input)
        {
            var champions = this.searchService.ReturnChampions<ChampionBasicViewModel>(input);

            return this.View(champions);
        }
    }
}
