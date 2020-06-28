using Management.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebUI.ViewComponents
{
    public class Products : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View(new List<ProductViewModel>() {
                new ProductViewModel(){Id=1,Name="Kemal1"},
                new ProductViewModel(){Id=2,Name="Kemal2"},
                new ProductViewModel(){Id=3,Name="Kemal3"},
                new ProductViewModel(){Id=4,Name="Kemal4"},
                new ProductViewModel(){Id=5,Name="Kemal5"},

            });
        }

    }
}
