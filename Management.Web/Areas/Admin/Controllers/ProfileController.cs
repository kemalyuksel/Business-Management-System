using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Management.Dto.DTOs.AppUserDTOs;
using Management.Entities.Concrete;
using Management.Web.BaseController;
using Management.Web.StringInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Management.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = AreaInfo.Admin)]
    public class ProfileController : BaseIdentityController
    {
       
        private readonly IMapper _mapper;

        public ProfileController(UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Profile;

            return View(_mapper.Map<AppUserListDto>(await GetLoggedUser()));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile Picture)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);

                if (Picture != null)
                {

                    var fileName = Picture.FileName.Split(".jpg");
                    string extension = Path.GetExtension(fileName+".png");
                    string picName = Guid.NewGuid() + extension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + picName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }

                    updatedUser.Picture = picName;
                }

                updatedUser.Name = model.Name;
                updatedUser.Surname = model.SurName;
                updatedUser.Email = model.Email;

                var result = await _userManager.UpdateAsync(updatedUser);

                if (result.Succeeded)
                {
                    TempData["updateMessage"] = "Güncelleme başarıyla gerçekleştirildi.";
                    return RedirectToAction("Index");
                }

                AddError(result.Errors);


            }

            return View(model);
        }


    }
}