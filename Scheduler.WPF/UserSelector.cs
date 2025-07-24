using Scheduler.Entities;
using Scheduler.Repositories;

namespace Scheduler.Services;

public class UserSelector
{
    private readonly Repository<User> _repository;

    public UserSelector(Repository<User> repository)
    {
        _repository = repository;
    }
    
    public User? User { get; private set; }

    public void Select(ulong id)
    {
        User = _repository.Find(id);
    }
    
    public void SelectUser(User user)
    {
        User = user;
    }
}
