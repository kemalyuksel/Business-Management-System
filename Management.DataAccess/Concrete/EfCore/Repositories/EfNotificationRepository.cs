using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Contexts;
using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.DataAccess.Concrete.EfCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetAllUnViewed(int appUserId)
        {
            using var context = new ManagementContext();

            return context.Notifications.Where(x => x.AppUserId == appUserId && !x.Status).ToList();
        }

        public int UnDisplayedNotificationCount(int id)
        {
            using var context = new ManagementContext();

            return context.Notifications.Count(x => x.AppUserId == id && !x.Status);
        }
    }
}
