using Scheduler.Entities;
using Scheduler.Factories;
using Scheduler.Repositories;
using Scheduler.Services;

namespace Scheduler.Tests;

public class EditTests
{
    private Repository<Labwork> _repository;
    private EntityFactory<Labwork> _factory; 
    private User _author;
    private Labwork _labwork;
    [SetUp]
    public void Setup()
    {
        _repository = [];
        _factory = new EntityFactory<Labwork>(_repository);
        _author = new User(0, "Aleksandr Hvastunov");
        _labwork = _factory.Create(id => new Labwork(
            identifier: id,
            name: string.Empty,
            description: string.Empty,
            criteria: string.Empty,
            author:   _author,
            maxScore: 15,
            parentIdentifier: null
        ));
    }

    [Test]
    public void EditLabwork()
    {
        var editResult = EditService<Labwork>.TryEdit(_author, _labwork, labwork => labwork.Description = "New description");

        Assert.Multiple(() =>
        {
            Assert.That(editResult is TryEditResult.Success);
            Assert.That(_labwork.Description, Is.EqualTo("New description"));
        });
    }
}