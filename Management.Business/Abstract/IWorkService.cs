using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Management.Business.Abstract
{
    public interface IWorkService : IService<Work>
    {
        List<Work> GetWithUrgencyUnCompletedWork();
        List<Work> GetWithAllTables();
        List<Work> GetWithAllTables(Expression<Func<Work, bool>> filter);
        List<Work> GetWithAllTablesNotCompleted(out int pageCount, int userId, int activePage = 1);
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
