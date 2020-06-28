using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Management.Business.Abstract;
using Management.Dto.DTOs.AppUserDTOs;
using Management.Dto.DTOs.ReportDTOs;
using Management.Dto.DTOs.WorkDTOs;
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
    public class WorkOrderController : BaseIdentityController
    {
        private readonly IAppUserService _appUserService;
        private readonly IWorkService _workService;
        private readonly INotificationService _notificationService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public WorkOrderController(IAppUserService appUserService, IWorkService workService,
            UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService
            , IMapper mapper) : base(userManager)
        {
            _appUserService = appUserService;
            _notificationService = notificationService;
            _workService = workService;
            _fileService = fileService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            return View(_mapper.Map<List<WorkListAllDto>>(_workService.GetWithAllTables()));
        }

        public IActionResult AssignStaff(int id, string key, int page = 1)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            ViewBag.activePage = page;

            ViewBag.search = key;

            var users = _mapper.Map<List<AppUserListDto>>(_appUserService.GetAllNonAdmin(out int pageCount, key, page));

            ViewBag.pageCount = pageCount;
            ViewBag.users = users;

            return View(_mapper.Map<WorkListDto>(_workService.GetWithUrgencyId(id)));
        }


        // bildirim gönder
        [HttpPost]
        public IActionResult AssignStaff(AssignPersonDto model)
        {

            var updatedWork = _workService.GetById(model.WorkId);
            updatedWork.AppUserId = model.PersonId;

            _workService.Update(updatedWork);

            _notificationService.Create(new Notification
            {
                AppUserId = model.PersonId,
                Description = $"{updatedWork.Name} isimli iş için görevlendirildiniz."
            });


            return RedirectToAction("Index");
        }


        public IActionResult AssignPerson(AssignPersonDto model)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            AssignPersonListDto personModel = new AssignPersonListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(x => x.Id == model.PersonId)),
                Work = _mapper.Map<WorkListDto>(_workService.GetWithUrgencyId(model.WorkId))
            };

            return View(personModel);
        }

        public IActionResult Detail(int id)
        {
            TempData["Active"] = TempDataInfo.WorkOrder;

            return View(_mapper.Map<WorkListAllDto>(_workService.GetWithReports(id)));
        }

        public IActionResult GetExcel(int id)
        {
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var list = _fileService.ExportExcel(_mapper.Map<List<ReportFileDto>>(
                _workService.GetWithReports(id).Reports));
            var fileName = Guid.NewGuid() + ".xlsx";

            return File(list, contentType, fileName);

        }

        public IActionResult GetPdf(int id)
        {
            var contentType = "application/pdf";
            var path = _fileService.ExportPdf(_mapper.Map<List<ReportFileDto>>(
                _workService.GetWithReports(id).Reports));

            var fileName = Guid.NewGuid() + ".pdf";

            return File(path, contentType, fileName);

        }

    }
}