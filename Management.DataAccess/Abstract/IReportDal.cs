using Management.Entities.Abstract;
using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.DataAccess.Abstract
{
    public interface IReportDal : IRepository<Report>
    {
        Report GetWithWorkId(int id);
        int GetUserReportCount(int id);
        int GetAllUserReportCount();

    }
}
