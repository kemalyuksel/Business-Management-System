using System.Collections.Generic;
using AutoMapper;
using Management.Business.Abstract;
using Management.Dto.DTOs.UrgencyDTOs;
using Management.Entities.Concrete;
using Management.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Management.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = AreaInfo.Admin)]
    public class UrgencyController : Controller
    {
        private readonly IUrgencyService _urgencyService;
        private readonly IMapper _mapper;

        public UrgencyController(IUrgencyService urgencyService, IMapper mapper)
        {
            _urgencyService = urgencyService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Urgency;

            return View(_mapper.Map<List<UrgencyListDto>>(_urgencyService.GetAll()));
        }


        public IActionResult AddUrgency()
        {
            TempData["Active"] = TempDataInfo.Urgency;
            return View(new UrgencyAddDto());
        }

        [HttpPost]
        public IActionResult AddUrgency(UrgencyAddDto model)
        {
            if (ModelState.IsValid)
            {
                _urgencyService.Create(new Urgency
                {
                    Description = model.Description,
                });

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult UpdateUrgency(int id)
        {
            TempData["Active"] = TempDataInfo.Urgency;

            return View(_mapper.Map<UrgencyUpdateDto>(_urgencyService.GetById(id)));
        }

        [HttpPost]
        public IActionResult UpdateUrgency(UrgencyUpdateDto model)
        {

            if (ModelState.IsValid)
            {
                _urgencyService.Update(new Urgency
                {
                    Id = model.Id,
                    Description = model.Description
                });

                return RedirectToAction("Index");

            }

            return View(model);

        }


    }
}