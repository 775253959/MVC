using CarManager.Core.Data;
using CarManager.Core.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;



namespace CarManager.Data
{
    public class RepositoryRgister :IDependencyRegister
    {
        public void RegisterTypes(IUnityContainer container)
        {
            //注入上下文
            container.RegisterType<IDbContext, CarDbContext>();
            //注入仓储 抽象
            container.RegisterType(typeof(IRepository<,>), typeof(EfRepository<,>));
        }
    }
}
