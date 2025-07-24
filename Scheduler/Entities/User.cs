namespace Scheduler.Entities;

public class User : IEntity<User>
{
    public User(ulong identifier, string name)
    {
        Identifier = identifier;
        Name = name;
    }
    public ulong Identifier { get; }
    public string Name { get; }
    
    public User Clone(ulong newIdentifier)
    {
        return new User(newIdentifier, Name);
    }
}