namespace Reviewer.Infrastructure.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
