using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Management.Business.Abstract;
using Management.Dto.DTOs.WorkDTOs;
using Management.Entities.Concrete;
using Management.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = AreaInfo.Admin)]
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
        private readonly IUrgencyService _urgenyService;
        private readonly IMapper _mapper;

        public WorkController(IWorkService workService, IUrgencyService urgenyService, IMapper mapper)
        {
            _workService = workService;
            _urgenyService = urgenyService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Work;

            return View(_mapper.Map<List<WorkListDto>>(_workService.GetWithUrgencyUnCompletedWork()));
        }

        public IActionResult AddWork()
        {
            TempData["Active"] = TempDataInfo.Work;

            ViewBag.Urgencies = new SelectList(_urgenyService.GetAll(), "Id", "Description");

            return View(new WorkAddDto());
        }

        [HttpPost]
        public IActionResult AddWork(WorkAddDto model)
        {
            if (ModelState.IsValid)
            {
                _workService.Create(new Work
                {
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId
                });

                return RedirectToAction("Index");

            }

            ViewBag.Urgencies = new SelectList(_urgenyService.GetAll(), "Id", "Description");

            return View(model);
        }


        public IActionResult UpdateWork(int id)
        {
            TempData["Active"] = TempDataInfo.Work;

            var work = _workService.GetById(id);

            ViewBag.Urgencies = new SelectList(_urgenyService.GetAll(), "Id", "Description", work.UrgencyId);

            return View(_mapper.Map<WorkUpdateDto>(work));
        }

        [HttpPost]
        public IActionResult UpdateWork(WorkUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _workService.Update(new Work
                {
                    Id = model.Id,
                    Description = model.Description,
                    Name = model.Name,
                    UrgencyId = model.UrgencyId
                });

                return RedirectToAction("Index");
            }

            ViewBag.Urgencies = new SelectList(_urgenyService.GetAll(), "Id", "Description", model.UrgencyId);

            return View(model);

        }

        public IActionResult DeleteWork(int id)
        {
            _workService.Delete(new Work { Id = id });

            Thread.Sleep(1000);

            return Json(null);
        }


    }
}