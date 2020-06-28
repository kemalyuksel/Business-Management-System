using Management.Entities.Concrete;
using System;

namespace Management.Dto.DTOs.WorkDTOs
{
    public class WorkListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Case { get; set; }
        public DateTime CreatedTime { get; set; }

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
    }
}
