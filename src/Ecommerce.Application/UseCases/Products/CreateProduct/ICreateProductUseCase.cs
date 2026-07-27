using Ecommerce.Communication.Requests.Products;
using Ecommerce.Communication.Responses.Products;

namespace Ecommerce.Application.UseCases.Products.CreateProduct;

public interface ICreateProductUseCase
{
    Task<ProductResponse> ExecuteAsync(CreateProductRequest request, CancellationToken cancellationToken);
}