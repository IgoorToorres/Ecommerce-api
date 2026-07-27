using Ecommerce.Application.Persistence;
using Ecommerce.Application.Repositories;
using Ecommerce.Communication.Requests.Products;
using Ecommerce.Communication.Responses.Products;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.UseCases.Products.CreateProduct;

public class CreateProductUseCase(IProductRepository repository, IUnitOfWork unitOfWork) : ICreateProductUseCase
{
    private readonly IProductRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ProductResponse> ExecuteAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name,
            request.Description,
            request.Price,
            request.StockQuantity
        );

        await _repository.AddAsync(product, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.StockQuantity,
            product.IsActive
        );

    }
}