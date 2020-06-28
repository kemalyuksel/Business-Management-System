using Management.Business.Abstract;
using Management.Business.Concrete;
using Management.Business.CustomLogger;
using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Management.Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IWorkDal, EfWorkRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }


    }
}
