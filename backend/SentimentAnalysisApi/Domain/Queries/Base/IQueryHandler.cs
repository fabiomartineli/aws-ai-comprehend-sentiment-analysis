namespace Domain.Queries.Base
{
    public interface IQueryHandler<TQuery, TResponse>
    {
        Task<TResponse> ExecuteAsync(TQuery query, CancellationToken cancellationToken);
    }
}
