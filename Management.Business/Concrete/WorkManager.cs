using Management.Business.Abstract;
using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Repositories;
using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Management.Business.Concrete
{
    public class WorkManager : IWorkService
    {
        private readonly IWorkDal _workDal;

        public WorkManager(IWorkDal workDal)
        {
            _workDal = workDal;
        }

        public void Create(Work entity)
        {
            _workDal.Create(entity);
        }

        public void Delete(Work entity)
        {
            _workDal.Delete(entity);
        }

        public List<Work> GetAll()
        {
            return _workDal.GetAll();
        }

        public int GetAllCompletedWorkCount()
        {
            return _workDal.GetAllCompletedWorkCount();
        }

        public Work GetById(int id)
        {
            return _workDal.GetById(id);
        }

        public int GetCompletedWorkCountWithUserId(int id)
        {
            return _workDal.GetCompletedWorkCountWithUserId(id);
        }

        public int GetUnAssignedWorkCount()
        {
            return _workDal.GetUnAssignedWorkCount();
        }

        public int GetUnCompletedWorkCountWithUserId(int id)
        {
            return _workDal.GetUnCompletedWorkCountWithUserId(id);
        }

        public int GetWaitedWorkCount()
        {
            return _workDal.GetWaitedWorkCount();
        }

        public List<Work> GetWithAllTables()
        {
            return _workDal.GetWithAllTables();
        }

        public List<Work> GetWithAllTables(Expression<Func<Work, bool>> filter)
        {
            return _workDal.GetWithAllTables(filter);
        }

        public List<Work> GetWithAllTablesNotCompleted(out int pageCount, int userId, int activePage)
        {
            return _workDal.GetWithAllTablesNotCompleted(out pageCount, userId, activePage);
        }

        public List<Work> GetWithAppUserId(int appUserId)
        {
            return _workDal.GetWithAppUserId(appUserId);
        }

        public Work GetWithReports(int id)
        {
            return _workDal.GetWithReports(id);
        }

        public Work GetWithUrgencyId(int id)
        {
            return _workDal.GetWithUrgencyId(id);
        }

        public List<Work> GetWithUrgencyUnCompletedWork()
        {
            return _workDal.GetWithUrgencyUnCompletedWork();
        }

        public void Update(Work entity)
        {
            _workDal.Update(entity);
        }
    }
}
