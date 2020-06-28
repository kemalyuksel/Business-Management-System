using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management.WebUI.CustomLogger;
using Management.WebUI.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Management.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PageError(int code)
        {
            ViewBag.error = code;

            return View();
        }

        public IActionResult Error()
        {

            var exceptionHandlerPath = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            NLogLogger nLogLogger = new NLogLogger();
            nLogLogger.LogWithNLog($"\nHatanın oluştuğu yer {exceptionHandlerPath.Path}\n" +
                $" Hata mesajı : {exceptionHandlerPath.Error.Message}\n" +
                $"Stack trace : {exceptionHandlerPath.Error.StackTrace}\n");

            ViewBag.Path = exceptionHandlerPath.Path;
            ViewBag.message = exceptionHandlerPath.Error.Message;

            return View();
        }

        public IActionResult Hata()
        {
            throw new Exception("Bir Hata oluştu amk");
        }
    }
}