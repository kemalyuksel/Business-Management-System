using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.DataAccess.Abstract
{
    public interface INotificationDal : IRepository<Notification>
    {

        List<Notification> GetAllUnViewed(int appUserId);
        int UnDisplayedNotificationCount(int id);

    }
}
