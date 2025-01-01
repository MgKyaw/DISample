public class DependencyResolver
{
    DependencyContainer _dependencyContainer;
    
    public DependencyResolver(DependencyContainer dependencyContainer)
    {
        _dependencyContainer = dependencyContainer;
    }

    public T GetService<T>()
    {
        var type = _dependencyContainer.GetDependency(typeof(T));
        return (T) Activator.CreateInstance(type);
    }
}