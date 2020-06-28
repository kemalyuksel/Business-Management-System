using Management.Business.Abstract;
using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Repositories;
using Management.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Business.Concrete
{
    public class ReportManager : IReportService
    {

        private readonly IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }

        public void Create(Report entity)
        {
            _reportDal.Create(entity);
        }

        public void Delete(Report entity)
        {
            _reportDal.Delete(entity);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public int GetAllUserReportCount()
        {
            return _reportDal.GetAllUserReportCount();
        }

        public Report GetById(int id)
        {
            return _reportDal.GetById(id);
        }

        public int GetUserReportCount(int id)
        {
            return _reportDal.GetUserReportCount(id);
        }

        public Report GetWithWorkId(int id)
        {
            return _reportDal.GetWithWorkId(id);
        }

        public void Update(Report entity)
        {
            _reportDal.Update(entity);
        }
    }
}
