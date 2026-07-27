namespace Ecommerce.Communication.Responses.Products;

public record ProductResponse
(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    bool IsActive
);