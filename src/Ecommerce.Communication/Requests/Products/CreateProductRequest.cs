namespace Ecommerce.Communication.Requests.Products;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int StockQuantity
);