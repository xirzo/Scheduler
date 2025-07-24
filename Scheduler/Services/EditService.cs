using Scheduler.Entities;
using Scheduler.Repositories;

namespace Scheduler.Services;

public abstract record TryEditResult
{
    private TryEditResult() {}
    
    public sealed record Success : TryEditResult;
    public sealed record EntityDoesNotExist(string EntityIdName) : TryEditResult;
    public sealed record UnauthorizedEditing(User User) : TryEditResult;
}

public class EditService<T> where T : IAuthored
{
    private readonly Repository<T> _repository;

    public EditService(Repository<T> repository)
    {
        _repository = repository;
    }
    
    // ? edit only through TryEdit ?
    // but setters and getters on the entity are public
    // maybe better to hide real object with it`s id

    public TryEditResult TryEdit(User user, T entity, Action<T> edit)
    {
        if (entity.Author != user)
        {
            return new TryEditResult.UnauthorizedEditing(user);
        }

        edit(entity);
        return new TryEditResult.Success();
    }
    
    public TryEditResult TryEdit(User user, ulong entityId, Action<T> edit)
    {
        var entity = _repository.Find(entityId);
        
        if (entity == null)
        {
            return new TryEditResult.EntityDoesNotExist(nameof(entityId));
        }
        
        if (entity.Author != user)
        {
            return new TryEditResult.UnauthorizedEditing(user);
        }

        edit(entity);
        return new TryEditResult.Success();
    }
}