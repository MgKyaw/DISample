public class DependencyResolver
{
    DependencyContainer _dependencyContainer;

    public DependencyResolver(DependencyContainer dependencyContainer)
    {
        _dependencyContainer = dependencyContainer;
    }

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }

    public object GetService(Type type)
    {
        var dependency = _dependencyContainer.GetDependency(type);
        var constructor = dependency.Type.GetConstructors().Single();
        var parameters = constructor.GetParameters().ToArray();

        if (parameters.Length > 0)
        {
            var parameterImplementations = new Object[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                parameterImplementations[i] = GetService(parameters[i].ParameterType);
            }

            return CreateImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementations));
        }

        return CreateImplementation(dependency, t => Activator.CreateInstance(t));
    }

    public object CreateImplementation(Dependency dependency, Func<Type, object> factory)
    {
        if(dependency.Implemented)
        {
            return dependency.Implementation;
        }

        var implementation = factory(dependency.Type);

        if(dependency.Lifetime == DependencyLifetime.Singleton)
        {
            dependency.AddImplementation(implementation);
        }

        return implementation;
    }
}