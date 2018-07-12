using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Core.IOC
{
    //dll查找器
    public interface ITypeSearcher
    {
        IList<Assembly> GetAssemblies();
        IEnumerable<Type> SearchClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);
        IEnumerable<Type> SearchClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);
        IEnumerable<Type> SearchClassesOfType<T>(bool onlyConcreteClasses=true);
        IEnumerable<Type> SearchClassesOfType<T>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

    }
}
