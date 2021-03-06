﻿using Management.Entities.Concrete;

namespace Management.Dto.DTOs.ReportDTOs
{
    public class ReportAddDto
    {
        public string Description { get; set; }

        public string Detail { get; set; }

        public Work Work { get; set; }
        public int WorkId { get; set; }
    }
}
