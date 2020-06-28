using FluentValidation;
using Management.Business.ValidationRules.FluentValidation;
using Management.DataAccess.Concrete.EfCore.Contexts;
using Management.Dto.DTOs.AppUserDTOs;
using Management.Dto.DTOs.ReportDTOs;
using Management.Dto.DTOs.UrgencyDTOs;
using Management.Dto.DTOs.WorkDTOs;
using Management.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Management.Web.CustomCollectionExtensions
{
    public static class CollectionExtension
    {

        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<ManagementContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "ManagementCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });
        }

        public static void AddCustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UrgencyAddDto>, UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyUpdateDto>, UrgencyUpdateValidator>();
            services.AddTransient<IValidator<AppUserRegisterDto>, AppUserAddValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserSignInValidator>();
            services.AddTransient<IValidator<WorkAddDto>, WorkAddValidator>();
            services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateValidator>();
            services.AddTransient<IValidator<ReportAddDto>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportUpdateDto>, ReportUpdateValidator>();
        }

    }
}
