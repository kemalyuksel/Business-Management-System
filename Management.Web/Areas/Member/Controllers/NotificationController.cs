using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Management.Business.Abstract;
using Management.Dto.DTOs.NotificationDTOs;
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
    public class NotificationController : BaseIdentityController
    {

        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Notification;
            var user = await GetLoggedUser();

            return View(_mapper.Map<List<NotificationListDto>>(_notificationService.GetAllUnViewed(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var updatedNotification = _notificationService.GetById(id);
            updatedNotification.Status = true;

            _notificationService.Update(updatedNotification);

            return RedirectToAction("Index");
        }
    }
}