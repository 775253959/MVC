using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManager.Core.Data;
using System.Data.Entity;

namespace CarManager.Data
{
    public class EfRepository<T,E> : IRepository<T,E> where T:class
    {
        readonly IDbContext dbContext;
        private IDbSet<T> dbSet;
        protected virtual IDbSet<T> DbSet
        {
            get { 
                this.dbSet=this.dbSet??dbContext.Set<T>();
                return this.dbSet;
            }
        }

        public EfRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T GetById(E id)
        {
            return this.DbSet.Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.DbSet.Add(entity);
            this.dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            
            this.dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

    }
}
