using Management.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default.png";

        public List<Work> Works { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
