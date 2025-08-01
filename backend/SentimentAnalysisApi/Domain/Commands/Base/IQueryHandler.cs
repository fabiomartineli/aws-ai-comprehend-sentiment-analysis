namespace Domain.Commands.Base
{
    public interface ICommandHandler<TCommand, TResponse>
    {
        Task<TResponse> ExecuteAsync(TCommand command, CancellationToken cancellationToken);
    }
}
