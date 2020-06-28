using Management.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.DataAccess.Abstract
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
