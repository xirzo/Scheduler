using Scheduler.Entities;
using Scheduler.Repositories;

namespace Scheduler.Factories;

public class IdentifiableFactory<T> where T : IIdentifiable
{
    private readonly Repository<T> _repository;

    public IdentifiableFactory(Repository<T> repository)
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
}