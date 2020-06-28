using Management.Entities.Concrete;
using System.Collections.Generic;

namespace Management.Business.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetAllNonAdmin();
        List<AppUser> GetAllNonAdmin(out int pageCount, string searchKey, int activePage = 1);
        List<DualHelper> Top5WorkCompleter();
        List<DualHelper> MostEmployeedAtWork();
    }
}
