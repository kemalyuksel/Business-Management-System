using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Contexts;
using Management.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.DataAccess.Concrete.EfCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public int GetAllUserReportCount()
        {
            using var context = new ManagementContext();

            return context.Reports.Count();
        }

        public int GetUserReportCount(int id)
        {
            using var context = new ManagementContext();

            var result = context.Works.Include(x => x.Reports).Where(x => x.AppUserId == id);

            return result.SelectMany(x => x.Reports).Count();
        }

        public Report GetWithWorkId(int id)
        {
            using var context = new ManagementContext();

            return context.Reports.Include(x => x.Work).ThenInclude(x => x.Urgency).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
