using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.Business.Abstract;
using Management.Entities.Concrete;
using Management.Web.BaseController;
using Management.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Management.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
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

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Home;

            var user = await GetLoggedUser();

            ViewBag.ReportCount = _reportService.GetUserReportCount(user.Id);
            ViewBag.WorkCount = _workService.GetCompletedWorkCountWithUserId(user.Id);
            ViewBag.UnWorkCount = _workService.GetUnCompletedWorkCountWithUserId(user.Id);
            ViewBag.NotificationCount = _notificationService.UnDisplayedNotificationCount(user.Id);

            return View();
        }
    }
}