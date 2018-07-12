using CarManager.Core.Cache;
using CarManager.Core.IOC;
using CarManager.Core.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CarManager.Service
{
    public class InfrastructureRegister:IDependencyRegister
    {

        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ICacheManager, RedisCacheManager>();
            container.RegisterType<ILogger,NullLogger>();
        }
    }
}
