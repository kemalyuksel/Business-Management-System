using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Contexts;
using Management.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Management.DataAccess.Concrete.EfCore.Repositories
{
    public class EfWorkRepository : EfGenericRepository<Work>, IWorkDal
    {
        public List<Work> GetWithAllTables()
        {
            using var context = new ManagementContext();
            return context.Works.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser)
            .Where(x => !x.Status).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public List<Work> GetWithAppUserId(int appUserId)
        {
            using var context = new ManagementContext();

            return context.Works.Where(x => x.AppUserId == appUserId).ToList();
        }

        public Work GetWithUrgencyId(int id)
        {
            using var context = new ManagementContext();
            return context.Works.Include(x => x.Urgency).FirstOrDefault(x => !x.Status && x.Id == id);
        }

        public List<Work> GetWithUrgencyUnCompletedWork()
        {
            using var context = new ManagementContext();
            return context.Works.Include(x => x.Urgency).Where(x => !x.Status).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public Work GetWithReports(int id)
        {
            using var context = new ManagementContext();
            return context.Works.Include(x => x.Reports).Include(x => x.AppUser).Where(x => x.Id == id).FirstOrDefault();

        }

        public List<Work> GetWithAllTables(Expression<Func<Work, bool>> filter)
        {
            using var context = new ManagementContext();
            return context.Works.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser)
            .Where(filter).OrderByDescending(x => x.CreatedTime).ToList();
        }

        public List<Work> GetWithAllTablesNotCompleted(out int pageCount, int userId, int activePage = 1)
        {
            using var context = new ManagementContext();
            var result = context.Works.Include(x => x.Urgency).Include(x => x.Reports).Include(x => x.AppUser)
            .Where(x => x.AppUserId == userId && x.Status).OrderByDescending(x => x.CreatedTime);

            pageCount = (int)Math.Ceiling((double)result.Count() / 3);

            return result.Skip((activePage - 1) * 3).Take(3).ToList();


        }

        public int GetCompletedWorkCountWithUserId(int id)
        {
            using var context = new ManagementContext();

            return context.Works.Count(x => x.AppUserId == id && x.Status);

        }

        public int GetUnCompletedWorkCountWithUserId(int id)
        {
            using var context = new ManagementContext();

            return context.Works.Count(x => x.AppUserId == id && !x.Status);
        }

        public int GetWaitedWorkCount()
        {
            using var context = new ManagementContext();

            return context.Works.Count(x => !x.Status && x.AppUser != null);
        }

        public int GetUnAssignedWorkCount()
        {
            using var context = new ManagementContext();

            return context.Works.Count(x => !x.Status && x.AppUser == null);
        }


        public int GetAllCompletedWorkCount()
        {
            using var context = new ManagementContext();

            return context.Works.Count(x => x.Status);
        }
    }
}
