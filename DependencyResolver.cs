public class DependencyResolver
{
    DependencyContainer _dependencyContainer;

    public DependencyResolver(DependencyContainer dependencyContainer)
    {
        _dependencyContainer = dependencyContainer;
    }

    public T GetService<T>()
    {
        return (T) GetService(typeof(T));
    }

    public object GetService(Type type)
    {
        var dependency = _dependencyContainer.GetDependency(type);
        var constructor = dependency.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length == 0)
        {
            return Activator.CreateInstance(dependency);
        }

        var parameterImplementations = new Object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameterImplementations[i] = GetService(parameters[i].ParameterType);
        }

        return Activator.CreateInstance(dependency, parameterImplementations);
    }
}