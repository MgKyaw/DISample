public class DependencyContainer
{
    List<Dependency> _dependencies;

    public DependencyContainer()
    {
        _dependencies = new List<Dependency>();
    }

    public void AddSingleton<T>()
    {
        _dependencies.Add(new Dependency(typeof(T), DependencyLifetime.Singleton));
    }
    
    public void AddTransient<T>()
    {        
        _dependencies.Add(new Dependency(typeof(T), DependencyLifetime.Transient));
    }

    public Dependency GetDependency(Type type)
    {
        return _dependencies.First(t => t.Type.Name == type.Name);
    }
}