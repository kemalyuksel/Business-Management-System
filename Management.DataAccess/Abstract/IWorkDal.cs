using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Management.DataAccess.Abstract
{
    public interface IWorkDal : IRepository<Work>
    {
        List<Work> GetWithUrgencyUnCompletedWork();
        List<Work> GetWithAllTables();
        List<Work> GetWithAllTables(Expression<Func<Work, bool>> filter);
        List<Work> GetWithAllTablesNotCompleted(out int pageCount,int userId,int activePage);   
        Work GetWithUrgencyId(int id);
        List<Work> GetWithAppUserId(int appUserId);
        Work GetWithReports(int id);
        int GetCompletedWorkCountWithUserId(int id);
        int GetUnCompletedWorkCountWithUserId(int id);
        int GetWaitedWorkCount();
        int GetAllCompletedWorkCount();
        int GetUnAssignedWorkCount();
    }
}
