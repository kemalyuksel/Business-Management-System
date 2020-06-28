using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Management.Business.Abstract;
using Management.Dto.DTOs.ReportDTOs;
using Management.Dto.DTOs.WorkDTOs;
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
    public class WorkOrderController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly IReportService _reportService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public WorkOrderController(IWorkService workService, UserManager<AppUser> userManager, IReportService reportService,
            INotificationService notificationService, IMapper mapper) :base(userManager)
        {
            _workService = workService;
            _reportService = reportService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            var user = await GetLoggedUser();

            return View(_mapper.Map<List<WorkListAllDto>>
                (_workService.GetWithAllTables(x => x.AppUserId == user.Id && !x.Status)));
        }


        public IActionResult AddReport(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            var work = _workService.GetWithUrgencyId(id);

            ReportAddDto model = new ReportAddDto
            {
                Work = work,
                WorkId = id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Create(new Report()
                {
                    WorkId = model.WorkId,
                    Description = model.Description,
                    Detail = model.Detail
                });

                var user = await GetLoggedUser();
                var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

                foreach (var admin in adminUserList)
                {
                    _notificationService.Create(new Notification
                    {
                        Description = $"{user.Name} {user.Surname} yeni bir rapor ekledi.",
                        AppUserId = admin.Id,
                    });
                }

                return RedirectToAction("Index");

            }

            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            var report = _reportService.GetWithWorkId(id);

            ReportUpdateDto model = new ReportUpdateDto
            {
                Id = report.Id,
                WorkId = report.WorkId,
                Work = report.Work,
                Detail = report.Detail,
                Description = report.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var updatedReport = _reportService.GetById(model.Id);

                updatedReport.Detail = model.Detail;
                updatedReport.Description = model.Description;

                _reportService.Update(updatedReport);

                return RedirectToAction("Index");

            }

            return View(model);
        }

        public async Task<IActionResult> CompleteWork(int id)
        {
            var updatedWork = _workService.GetById(id);

            updatedWork.Status = true;
            _workService.Update(updatedWork);

            var user = await GetLoggedUser();
            var adminUserList = await _userManager.GetUsersInRoleAsync("Admin");

            foreach (var admin in adminUserList)
            {
                _notificationService.Create(new Notification
                {
                    Description = $"{user.Name} {user.Surname} bir görevi tamamladı.",
                    AppUserId = admin.Id,
                });
            }

            return Json(null);
        }


    }
}