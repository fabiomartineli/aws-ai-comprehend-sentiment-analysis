namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task StartTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
    }
}
