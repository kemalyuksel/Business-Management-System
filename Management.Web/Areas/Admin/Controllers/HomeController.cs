using System.Threading.Tasks;
using Management.Business.Abstract;
using Management.Entities.Concrete;
using Management.Web.BaseController;
using Management.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Management.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;

        public HomeController(IReportService reportService, UserManager<AppUser> userManager, IWorkService workService,
            INotificationService notificationService) : base(userManager)
        {
            _reportService = reportService;
            _workService = workService;
            _notificationService = notificationService;
        }

        /*
         toplam yazılmış rapor
         */

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Home;

            var user = await GetLoggedUser();

            ViewBag.WorkCount = _workService.GetWaitedWorkCount();
            ViewBag.NotificationCount = _notificationService.UnDisplayedNotificationCount(user.Id);
            ViewBag.CompletedWorkCount = _workService.GetAllCompletedWorkCount();
            ViewBag.ReportCount = _reportService.GetAllUserReportCount();
            ViewBag.UnAssignedWorkCount = _workService.GetUnAssignedWorkCount();


            return View();
        }
    }
}