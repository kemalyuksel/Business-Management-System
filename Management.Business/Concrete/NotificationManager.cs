using Management.Business.Abstract;
using Management.DataAccess.Abstract;
using Management.Entities.Concrete;
using System.Collections.Generic;

namespace Management.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Create(Notification entity)
        {
            _notificationDal.Create(entity);
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public List<Notification> GetAllUnViewed(int appUserId)
        {
            return _notificationDal.GetAllUnViewed(appUserId);
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public int UnDisplayedNotificationCount(int id)
        {
            return _notificationDal.UnDisplayedNotificationCount(id);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
