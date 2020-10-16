using System;
using CratiaApp.Business.Logic.Services.Common;
using CratiaApp.Business.Logic.Services.Common.Certificates;
using CratiaApp.Business.Logic.Services.Common.Discounts;
using CratiaApp.Business.Logic.Services.Common.Payments;
using CratiaApp.Bussines.Logic.Services;
using CratiaApp.DataAccess.Context;
using CratiaApp.DataAccess.UnitOfWork;
using Unity;
using Unity.Lifetime;

namespace CratiaApp.Business.Logic.Unity
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static partial class UnityConfig<T>
        where T : ITypeLifetimeManager, new()
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

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
            container.RegisterType<CratiaAppDbContext, CratiaAppDbContext>(CreateLifetimeManager());

            container.RegisterType<ICratiaAppUnitOfWork, CratiaAppUnitOfWork>(CreateLifetimeManager());

            container.RegisterType<IBattleService, BattleService>(CreateLifetimeManager());
            container.RegisterType<IBoxerService, BoxerService>(CreateLifetimeManager());
        }

        private static ITypeLifetimeManager CreateLifetimeManager()
        {
            return Activator.CreateInstance(typeof(T)) as ITypeLifetimeManager;
        }
    }
}