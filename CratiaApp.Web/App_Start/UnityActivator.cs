using CratiaApp.Business.Logic.Unity;
using CratiaApp.Business.Logic.Unity.DependencyResolvers;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CratiaApp.Web.UnityWebApiActivator), nameof(CratiaApp.Web.UnityWebApiActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(CratiaApp.Web.UnityWebApiActivator), nameof(CratiaApp.Web.UnityWebApiActivator.Shutdown))]

namespace CratiaApp.Web
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with WebApi when it is hosted in ASP.NET.
    /// </summary>
    public static class UnityWebApiActivator
    {
        private static IUnityContainer Container => UnityConfig<PerRequestLifetimeManager>.Container;

        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(Container));

            DependencyResolver.SetResolver(new Unity.AspNet.Mvc.UnityDependencyResolver(Container));

            //Uncomment if you want to use PerRequestLifetimeManager
            Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));

            // Use UnityHierarchicalDependencyResolver if you want to use
            // a new child container for each IHttpController resolution.
            // var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
            //var resolver = new UnityDependencyResolver(UnityConfig.Container);

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.AspNet.WebApi.UnityDependencyResolver(Container);

            GlobalDependencyResolver.DependencyResolver = new PerRequestDependencyResolver();
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            Container.Dispose();
        }

        class PerRequestDependencyResolver : CratiaApp.Business.Logic.Unity.DependencyResolvers.IDependencyResolver
        {
            T Business.Logic.Unity.DependencyResolvers.IDependencyResolver.GetService<T>()
            {
                return DependencyResolver.Current.GetService<T>();
            }
        }
    }
}