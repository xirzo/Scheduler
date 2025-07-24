namespace Scheduler.Entities;

public interface IEntity<out T> where T : IEntity<T>
{
    ulong Identifier { get; }
    T Clone(ulong newIdentifier);
}