namespace Scheduler.Entities;

public enum FinalsType
{
    Exam,
    Test,
}

public class Subject : IIdentifiable, ICloneable<Subject>, IAuthored
{
    public Subject(
        ulong identifier, 
        string name, 
        IReadOnlyCollection<Labwork> labworks, 
        IReadOnlyCollection<LectureMaterial> lectureMaterials, 
        FinalsType finalsType,
        User author, 
        ulong? parentIdentifier,
        ulong? score = null,          
        ulong? minTestScore = null)   
    {
        Identifier = identifier;
        Name = name;
        Labworks = labworks;
        LectureMaterials = lectureMaterials;
        FinalsType = finalsType;
        Author = author;
        ParentIdentifier = parentIdentifier;
        
        Score = finalsType == FinalsType.Exam ? score : null;
        MinTestScore = finalsType == FinalsType.Test ? minTestScore : null;
    }

    public ulong Identifier { get; }
    public string Name { get; set; }
    public IReadOnlyCollection<Labwork> Labworks { get; }
    public IReadOnlyCollection<LectureMaterial> LectureMaterials { get; }
    public FinalsType FinalsType { get; }
    public ulong? Score { get; }
    public ulong? MinTestScore { get; }
    public User Author { get; }
    public ulong? ParentIdentifier { get; }
    
    public Subject Clone(ulong newIdentifier)
    {
        return new Subject(
            newIdentifier,
            Name,
            Labworks,
            LectureMaterials,
            FinalsType,
            Author,
            ParentIdentifier,
            Score,
            MinTestScore);
    }
}
