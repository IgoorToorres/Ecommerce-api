using Ecommerce.Application.UseCases.Products.CreateProduct;
using Ecommerce.Communication.Requests.Products;
using Ecommerce.Communication.Responses.Products;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(ICreateProductUseCase createProductUseCase) : ControllerBase
{
    private readonly ICreateProductUseCase _createProductUseCase = createProductUseCase;

    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await _createProductUseCase.ExecuteAsync(request, cancellationToken);
        return Created(string.Empty, response);
    }
}