using System.Collections;
using Scheduler.Factories;

namespace Scheduler.Repositories;

public class Repository<T> : IEnumerable<T>
{
    private readonly Dictionary<ulong, T> _entities = new();
    public ulong LastId { get; private set; }

    public ulong Add(T entity)
    {
        _entities[LastId] = entity;
        var lastId = LastId;
        LastId++;
        return lastId;
    }

    public T? Find(ulong id)
    {
        return _entities.GetValueOrDefault(id);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _entities.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}