using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Management.WebUI.ViewModels
{
    public class TestViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
