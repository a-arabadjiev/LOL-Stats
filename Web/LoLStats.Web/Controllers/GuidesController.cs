namespace LoLStats.Web.Controllers
{
    using LoLStats.Services.Data;
    using LoLStats.Web.ViewModels.Champions;
    using LoLStats.Web.ViewModels.Guides;
    using LoLStats.Web.ViewModels.SummonerSpells;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class GuidesController : BaseController
    {
        private readonly IChampionRolesService championRolesService;
        private readonly IChampionsService championsService;
        private readonly ISummonerSpellsService summonerSpellsService;

        public GuidesController(
            IChampionRolesService championRolesService,
            IChampionsService championsService,
            ISummonerSpellsService summonerSpellsService)
        {
            this.championRolesService = championRolesService;
            this.championsService = championsService;
            this.summonerSpellsService = summonerSpellsService;
        }

        public IActionResult All()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            var viewModel = new GuideInputModel
            {
                Roles = this.championRolesService.GetAll(),
                AllChampions = this.championsService.GetAll<ChampionBasicViewModel>(),
                AllSummonerSpells = this.summonerSpellsService.GetAll<SummonerSpellViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(GuideInputModel input)
        {
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
