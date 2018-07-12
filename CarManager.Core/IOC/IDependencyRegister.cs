using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CarManager.Core.IOC
{
    public interface IDependencyRegister
    {
        void RegisterTypes(IUnityContainer container);
    }
}
