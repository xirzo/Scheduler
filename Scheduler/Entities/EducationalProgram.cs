namespace Scheduler.Entities;

// TODO: tie subjects to semesters
public class EducationalProgram : IIdentifiable
{
    public EducationalProgram(ulong identifier, string name, IReadOnlyCollection<Subject> subjects, User supervisor)
    {
        Identifier = identifier;
        Name = name;
        Subjects = subjects;
        Supervisor = supervisor;
    }
    public string Name { get; }
    public IReadOnlyCollection<Subject> Subjects { get; }
    public User Supervisor { get; }
    public ulong Identifier { get; }
}