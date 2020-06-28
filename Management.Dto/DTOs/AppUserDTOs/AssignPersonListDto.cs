using Management.Dto.DTOs.WorkDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Dto.DTOs.AppUserDTOs
{
    public class AssignPersonListDto
    {
        public AppUserListDto AppUser { get; set; }
        public WorkListDto Work { get; set; }
    }
}
