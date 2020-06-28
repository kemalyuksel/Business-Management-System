using Management.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Entities.Concrete
{
    public class Notification : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
