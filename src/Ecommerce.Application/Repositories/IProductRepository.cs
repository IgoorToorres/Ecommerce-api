using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken cancellationToken);
}
