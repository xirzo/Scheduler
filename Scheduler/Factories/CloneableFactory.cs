using Scheduler.Entities;
using Scheduler.Repositories;

namespace Scheduler.Factories;

public class CloneableFactory<T> where T : ICloneable<T>, IIdentifiable
{
    private readonly IdentifiableFactory<T> _factory;

    public CloneableFactory(Repository<T> repository)
    {
        _factory = new IdentifiableFactory<T>(repository);
    }
    
    public T Create(Func<ulong, T> factory)
    {
        return _factory.Create(factory);
    }

    public T CreateFrom(T parent)
    {
        return _factory.Create(id => parent.Clone(id));
    }
}