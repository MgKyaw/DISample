public class Dependency 
{
    public Dependency(Type type, DependencyLifetime lifetime)
    {
        Type = type;
        Lifetime = lifetime;
    }
    public Type Type { get; set; }
    public DependencyLifetime Lifetime { get; set; }
    public object Implementation { get; set; }
    public bool Implemented { get; set; }

    public void AddImplementation(object i)
    {
        Implementation = i;
        Implemented = true;
    }
}