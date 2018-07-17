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
            //注册哪种缓存，就使用哪种缓存，不使用就注册空
            container.RegisterType<ICacheManager, RedisCacheManager>();
            //注册哪种日志就使用哪种日志，不使用就注册空
            container.RegisterType<ILogger,NullLogger>();
        }
    }
}
