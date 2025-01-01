public class DependencyResolver
{
    DependencyContainer _dependencyContainer;

    public DependencyResolver(DependencyContainer dependencyContainer)
    {
        _dependencyContainer = dependencyContainer;
    }

    public T GetService<T>()
    {
        var dependency = _dependencyContainer.GetDependency(typeof(T));
        var constructor = dependency.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length == 0)
        {
            return (T)Activator.CreateInstance(dependency);
        }

        var parameterImplementations = new Object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameterImplementations[i] = Activator.CreateInstance(parameters[i].ParameterType);
        }

        return (T)Activator.CreateInstance(dependency, parameterImplementations);
    }
}