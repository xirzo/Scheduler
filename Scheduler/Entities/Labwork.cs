namespace Scheduler.Entities
{
    public class Labwork : IEntity<Labwork>, IAuthored
    {
        public Labwork(ulong identifier, string name, string description, string criteria, ulong maxScore, User author, ulong? parentIdentifier)
        {
            Identifier = identifier;
            Name = name;
            Description = description;
            Criteria = criteria;
            MaxScore = maxScore;
            Author = author;
            ParentIdentifier = parentIdentifier;
        }

        public ulong Identifier { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Criteria { get; set; }
        public ulong MaxScore { get; }
        public User Author { get; }
        public ulong? ParentIdentifier { get; }
    
        public Labwork Clone(ulong newIdentifier)
        {
            return new Labwork(newIdentifier, Name, Description, Criteria, MaxScore, Author, Identifier);
        }
    }
}