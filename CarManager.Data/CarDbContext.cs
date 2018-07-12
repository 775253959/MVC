using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace CarManager.Data
{
    public class CarDbContext:DbContext,IDbContext
    {

        static CarDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarDbContext>());
        }

        public CarDbContext()
            : base("carDatabase")
        {
        
        }    

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql,parameters);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           // modelBuilder.Configurations.Add(new CarManager.Data.Mapping.CarMap());
            
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
