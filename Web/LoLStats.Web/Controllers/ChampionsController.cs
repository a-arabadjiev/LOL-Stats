namespace LoLStats.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LoLStats.Services.Data;
    using LoLStats.Web.ViewModels;
    using LoLStats.Web.ViewModels.Champions;
    using Microsoft.AspNetCore.Mvc;

    public class ChampionsController : BaseController
    {
        private readonly IChampionsService championsService;

        public ChampionsController(IChampionsService championsService)
        {
            this.championsService = championsService;
        }

        public IActionResult All()
        {
            var viewModel = new ChampionsListViewModel
            {
                Champions = this.championsService.GetAll<ChampionInListViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(string id)
        {

        }
    }
}
