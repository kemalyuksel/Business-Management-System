using Management.DataAccess.Abstract;
using Management.DataAccess.Concrete.EfCore.Contexts;
using Management.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Management.DataAccess.Concrete.EfCore.Repositories
{
    public class EfGenericRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        public void Create(T entity)
        {
            using var context = new ManagementContext();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var context = new ManagementContext();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            using var context = new ManagementContext();
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new ManagementContext();
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var context = new ManagementContext();
            return context.Set<T>().Find(id);
        }
    }
}
