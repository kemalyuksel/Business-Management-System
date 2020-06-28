using Management.DataAccess.Abstract;
using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.DataAccess.Concrete.EfCore.Repositories
{
    public class EfUrgencyRepository : EfGenericRepository<Urgency>, IUrgencyDal
    {
    }
}
