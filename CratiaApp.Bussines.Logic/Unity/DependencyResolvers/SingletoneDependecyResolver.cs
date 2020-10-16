using CratiaApp.Business.Logic.Unity.DependencyResolvers;
using Unity;
using Unity.Lifetime;

namespace CratiaApp.Business.Logic.Unity
{
    public class SingletoneDependecyResolver : IDependencyResolver
    {
        public T GetService<T>()
        {
            return UnityConfig<SingletonLifetimeManager>.Container.Resolve<T>();
        }
    }
}