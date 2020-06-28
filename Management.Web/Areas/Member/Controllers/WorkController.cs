using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Management.Business.Abstract;
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
    public class WorkController : BaseIdentityController
    {
        private readonly IWorkService _workService;
        private readonly IMapper _mapper;

        public WorkController(IWorkService workService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _workService = workService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int activePage = 1)
        {
            TempData["Active"] = TempDataInfo.Work;

            var user = await GetLoggedUser();

            var model = _mapper.Map<List<WorkListAllDto>>(_workService.
                GetWithAllTablesNotCompleted(out int pageCount, user.Id, activePage));

            ViewBag.PageCount = pageCount;
            ViewBag.ActivePage = activePage;

            return View(model);
        }
    }
}