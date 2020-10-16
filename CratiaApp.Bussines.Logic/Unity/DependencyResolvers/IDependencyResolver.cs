namespace CratiaApp.Business.Logic.Unity.DependencyResolvers
{
    public interface IDependencyResolver
    {
        T GetService<T>();
    }
}