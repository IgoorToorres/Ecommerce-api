using Ecommerce.Application.Persistence;

namespace Ecommerce.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly EcommerceDbContext _dbContext;

    public UnitOfWork(EcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
