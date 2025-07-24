using Scheduler.Entities;
using Scheduler.Factories;
using Scheduler.Repositories;

namespace Scheduler.Tests;

public class LabworkCreationTests
{
    private Repository<Labwork> _repository;
    private CloneableFactory<Labwork> _factory;
    private User _author;
    
    [SetUp]
    public void Setup()
    {
        _repository = [];
        _factory = new CloneableFactory<Labwork>(_repository);
        _author = new User(0, "Alex");
    }
    
    [Test]
    public void CreateFrom_WhenCreatingChildLabwork_ShouldSetParentIdentifierToParentLabworkIdentifier()
    {
        var labworkParent = _factory.Create(id => new Labwork( 
            identifier: id,
            name: string.Empty,
            description: string.Empty,
            criteria: string.Empty,
            author:   _author,
            maxScore: 15,
            parentIdentifier: null
        ));
        var labworkChild = _factory.CreateFrom(labworkParent);
        
        Assert.That(labworkChild.ParentIdentifier, Is.EqualTo(labworkParent.Identifier));
    }
}
