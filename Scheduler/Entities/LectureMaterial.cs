namespace Scheduler.Entities;

public class LectureMaterial : IIdentifiable, ICloneable<LectureMaterial>, IAuthored
{
    public LectureMaterial(ulong identifier, string name, string description, string content, User author, ulong? parentIdentifier)
    {
        Identifier = identifier;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
        ParentIdentifier = parentIdentifier;
    }
    public ulong Identifier { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Content{ get; set; }
    public User Author { get; }
    public ulong? ParentIdentifier { get; }
    public LectureMaterial Clone(ulong newIdentifier)
    {
        return new LectureMaterial(newIdentifier, Name, Description, Content, Author, Identifier);
    }
}