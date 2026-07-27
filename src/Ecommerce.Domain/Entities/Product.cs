using Ecommerce.Exception.Exceptions;

namespace Ecommerce.Domain.Entities;

public class Product
{
    public Guid Id {get; private set;}
    public string Name {get; private set;} = string.Empty;
    public string Description {get; private set;} = string.Empty;
    public decimal Price {get; private set;}
    public int StockQuantity {get; private set;}
    public bool IsActive {get; private set;}
    public DateTime CreatedAt {get; private set;}
    public DateTime UpdatedAt {get; private set;}


    // TODO: formatar DomainExceptions corretamente para mensagens padroes


    public Product(string name, string description, decimal price, int stockQuantity)
    {
        ValidateName(name);
        ValidatePrice(price);
        ValidateStockQuantity(stockQuantity);

        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }


    public void ChangePrice(decimal price)
    {
        ValidatePrice(price);

        Price = price;
        UpdateAt();
    }

    public void IncreaseStock(int quantity)
    {
        ValidateQuantityGreaterThanZero(quantity);
       
        StockQuantity += quantity;
        UpdateAt();
    }


    public void DecreaseStock(int quantity)
    {
        ValidateQuantityGreaterThanZero(quantity);
        if(StockQuantity < quantity) throw new DomainException("Estoque insuficiente.");

        StockQuantity -= quantity;
        UpdateAt();
    }

    public void Activate()
    {
        if(IsActive) throw new DomainException("Produto ja esta ativo.");
        ValidateName(Name);
        ValidatePrice(Price);

        IsActive = true;
        UpdateAt();

    }

    public void Deactivate()
    {
        if(!IsActive) throw new DomainException("Produto ja esta inativo.");

        IsActive = false;
        UpdateAt();
    }

    public bool HasAvailableStock(int quantity)
    {
        if(quantity <= 0) return false;
        if(!IsActive) return false;
        return StockQuantity >= quantity;
    }

    public void UpdateDetails(string name, string description)
    {
        ValidateName(name);

        Name = name;
        Description = description;
        UpdateAt();
    }

    private void UpdateAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }

    private static void ValidateName(string name)
    {
        if(string.IsNullOrWhiteSpace(name)) throw new DomainException("O nome do produto é obrigatório.");
    }

    private static void ValidatePrice(decimal price)
    {
        if(price <= 0) throw new DomainException("O preço deve ser maior que zero.");
    }

    private static void ValidateStockQuantity(int stockQuantity)
    {
        if(stockQuantity < 0) throw new DomainException("O estoque não pode ser negativo.");
    }

    private static void ValidateQuantityGreaterThanZero(int quantity)
    {
         if (quantity <= 0) throw new DomainException("A quantidade deve ser maior que zero.");
    }

}
