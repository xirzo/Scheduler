using Scheduler.Entities;

namespace Scheduler.Services;

public abstract record TryEditResult
{
    private TryEditResult() {}
    
    public sealed record Success : TryEditResult;
    public sealed record EntityDoesNotExist(string EntityIdName) : TryEditResult;
    public sealed record UnauthorizedEditing(User User) : TryEditResult;
}

public static class EditService<T> where T : IAuthored
{
    public static TryEditResult TryEdit(User user, T entity, Action<T> edit)
    {
        if (entity.Author != user)
        {
            return new TryEditResult.UnauthorizedEditing(user);
        }

        edit(entity);
        return new TryEditResult.Success();
    }
}