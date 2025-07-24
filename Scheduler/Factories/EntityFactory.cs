using Scheduler.Entities;
using Scheduler.Repositories;

namespace Scheduler.Factories;

public class EntityFactory<T> where T : IEntity<T>
{
    private readonly Repository<T> _repository;

    public EntityFactory(Repository<T> repository)
    {
        _repository = repository;
    }

    public T Create(Func<ulong, T> factory)
    {
        var id = _repository.LastId;
        var entity = factory(id);
        _repository.Add(entity);
        return entity;
    }

    public T CreateFrom(T parent)
    {
        var child = parent.Clone(_repository.LastId);
        _repository.Add(child);
        return child;
    }
}