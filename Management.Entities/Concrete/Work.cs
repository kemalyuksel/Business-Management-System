using Management.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Management.Entities.Concrete
{
    public class Work : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }

        public List<Report> Reports { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
