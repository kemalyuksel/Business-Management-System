using Management.Entities.Concrete;

namespace Management.Business.Abstract
{
    public interface IReportService : IService<Report>
    {
        Report GetWithWorkId(int id);
        int GetUserReportCount(int id);
        int GetAllUserReportCount();
    }
}
