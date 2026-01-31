using Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infra.Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        private IDbContextTransaction _transcation;

        public async Task StartTransactionAsync(CancellationToken cancellationToken)
        {
            _transcation ??= await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                await _transcation.CommitAsync(cancellationToken);
            }
            catch
            {
                await _transcation.RollbackAsync(cancellationToken);
                throw;
            }
            finally
            {
                await _transcation.DisposeAsync();
                _transcation = null;
            }
        }
    }
}
