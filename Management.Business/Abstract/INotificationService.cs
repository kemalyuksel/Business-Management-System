using Management.Entities.Concrete;
using System.Collections.Generic;

namespace Management.Business.Abstract
{
    public interface INotificationService : IService<Notification>
    {
        List<Notification> GetAllUnViewed(int appUserId);
        int UnDisplayedNotificationCount(int id);
    }
}
