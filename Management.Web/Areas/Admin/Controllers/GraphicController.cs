using Management.Business.Abstract;
using Management.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Management.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = AreaInfo.Admin)]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;

        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult MostCompleter()
        {

            var jsonString = JsonConvert.SerializeObject(_appUserService.MostEmployeedAtWork());

            return Json(jsonString);
        }

        public IActionResult TopWorkCompleter()
        {

            var jsonString = JsonConvert.SerializeObject(_appUserService.Top5WorkCompleter());

            return Json(jsonString);
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Graphic;

            return View();
        }
    }
}