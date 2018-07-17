using CarManager.Core.Config;
using CarManager.Core.IOC;
using CarManager.WebCore.IOC;
using System;
using System.Configuration;
using Unity;

namespace CarManager.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        //暂时不要了
        //private static Lazy<IUnityContainer> container =
        //  new Lazy<IUnityContainer>(() =>
        //  {
        //      var container = new UnityContainer();
        //      RegisterTypes(container);
        //      return container;
        //  });


        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            RegisterTypes(ServiceContainer.Current);
            return ServiceContainer.Current;
        }
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {

            //初始化注入
            container.RegisterInstance<IUnityContainer>(container);
            ITypeSearcher typeFinder = new WebTypeSearcher();

            var config = ConfigurationManager.GetSection("applicationConfig") as ApplicationConfig;
            container.RegisterInstance<ApplicationConfig>(config);

            var registerTypes = typeFinder.SearchClassesOfType<IDependencyRegister>();
            foreach (var registerType in registerTypes)
            {
                var register = (IDependencyRegister)Activator.CreateInstance(registerType);
                register.RegisterTypes(container);
            }

        }
    }
}