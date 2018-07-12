using CarManager.Core.IOC;
using CarManager.Service.CarInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CarManager.Service
{
    public class ServiceRegister:IDependencyRegister
    {

        public void RegisterTypes(IUnityContainer container)
        {
            //可替换注入的内容
            container.RegisterType<ICarInfoService,CarInfoService>();
        }
    }
}
