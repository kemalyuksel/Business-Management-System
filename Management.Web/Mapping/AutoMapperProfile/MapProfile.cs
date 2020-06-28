using AutoMapper;
using Management.Dto.DTOs;
using Management.Dto.DTOs.AppUserDTOs;
using Management.Dto.DTOs.NotificationDTOs;
using Management.Dto.DTOs.ReportDTOs;
using Management.Dto.DTOs.UrgencyDTOs;
using Management.Dto.DTOs.WorkDTOs;
using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            #region Urgency-UrgencyDto
            CreateMap<UrgencyAddDto, Urgency>();
            CreateMap<Urgency, UrgencyAddDto>();
            CreateMap<UrgencyListDto, Urgency>();
            CreateMap<Urgency, UrgencyListDto>();
            CreateMap<UrgencyUpdateDto, Urgency>();
            CreateMap<Urgency, UrgencyUpdateDto>();
            #endregion

            #region AppUser-AppUserDto
            CreateMap<AppUserRegisterDto, AppUser>();
            CreateMap<AppUser, AppUserRegisterDto>();
            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            #endregion

            #region Report-ReportDto
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();
            CreateMap<ReportFileDto, Report>();
            CreateMap<Report, ReportFileDto>();
            #endregion

            #region Work-WorkDto
            CreateMap<WorkAddDto, Work>();
            CreateMap<Work, WorkAddDto>();
            CreateMap<WorkListDto, Work>();
            CreateMap<Work, WorkListDto>();
            CreateMap<WorkUpdateDto, Work>();
            CreateMap<Work, WorkUpdateDto>();
            CreateMap<WorkListAllDto, Work>();
            CreateMap<Work, WorkListAllDto>();
            #endregion

            #region Notification-NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

        }

    }
}
