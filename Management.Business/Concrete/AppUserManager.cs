using Management.Business.Abstract;
using Management.DataAccess.Abstract;
using Management.Entities.Concrete;
using System.Collections.Generic;

namespace Management.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _userDal;

        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> GetAllNonAdmin()
        {
            return _userDal.GetAllNonAdmin();
        }

        public List<AppUser> GetAllNonAdmin(out int pageCount, string searchKey, int activePage = 1)
        {
            return _userDal.GetAllNonAdmin(out pageCount, searchKey, activePage);
        }

        public List<DualHelper> MostEmployeedAtWork()
        {
            return _userDal.MostEmployeedAtWork();
        }

        public List<DualHelper> Top5WorkCompleter()
        {
            return _userDal.Top5WorkCompleter();
        }
    }
}
