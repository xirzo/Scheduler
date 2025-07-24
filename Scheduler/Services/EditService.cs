using Scheduler.Entities;

namespace Scheduler.Services;

public class EditService<T> where T : IAuthored
{
    private readonly User _user;

    public EditService(User user)
    {
        _user = user;
    }

    // TODO: add error type with record
    public void TryEdit(User user, T entity)
    {
        if (entity.Author != user)
        {
            return;
        }
        
    }
}