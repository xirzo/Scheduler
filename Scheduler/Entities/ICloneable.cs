namespace Scheduler.Entities;

public interface ICloneable<out T> where T : IIdentifiable
{
    T Clone(ulong newIdentifier);
}