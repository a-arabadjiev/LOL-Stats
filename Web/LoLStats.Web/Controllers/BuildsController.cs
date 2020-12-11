namespace LoLStats.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BuildsController : BaseController
    {
        public IActionResult All()
        {
            return this.View();
        }
    }
}
