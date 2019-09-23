using Demo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;  
using System.Linq;
using System.Text;
namespace Demo.DataAccess.DataAccessObjects
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _entities; 
        public DbContext Context;

        public GenericRepository(IUnitOfWork<WebDbContext> unitOfWork)
        {
            Context = unitOfWork.Context;
        }

        public virtual IQueryable<T> Table
        {
            get { return Entities; }
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                return _entities ?? (_entities = Context.Set<T>());
            }
        }

        public T Create(T t)
        {
            Entities.Add(t);
            return t;
        }

        public bool Delete(T t)
        {
            Entities.Remove(t);
            return true;
        }

        public IEnumerable<T> Filter(Func<T, bool> func)
        {
            var results = Entities.Where(func);
            return results;
        }

        public bool Update(T t)
        {
            Context.Entry(t).State = EntityState.Modified;
            return true;
        }
    }
}
