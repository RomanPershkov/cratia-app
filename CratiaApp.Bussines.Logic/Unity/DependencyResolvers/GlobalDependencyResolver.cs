using Unity;

namespace CratiaApp.Business.Logic.Unity.DependencyResolvers
{
    public static class GlobalDependencyResolver
    {
        public static IUnityContainer UnityContainer { get; set; }

        public static IDependencyResolver DependencyResolver { get; set; }

        public static T GetService<T>()
        {
            return DependencyResolver.GetService<T>();
        }
    }
}