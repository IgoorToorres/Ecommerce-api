using Ecommerce.Domain.Entities;
using Ecommerce.Exception.Exceptions;

namespace Ecommerce.UnitTests.Domain.Entities;


// Esta classe testa as regras de negócio da entidade Product.
// Os testes verificam se o produto nasce válido,
// se bloqueia dados inválidos,
// se controla alterações de preço e estoque,
// se ativa/desativa corretamente,
// se verifica disponibilidade de estoque,
// e se atualiza nome e descrição com validação.


public class ProductTests
{
    [Fact]
    public void Should_Create_Product_When_Data_Is_Valid()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        Assert.NotEqual(Guid.Empty, product.Id);
        Assert.Equal("Teclado mecanico", product.Name);
        Assert.Equal("Teclado mecanico com switches brown", product.Description);
        Assert.Equal(399.90m, product.Price);
        Assert.Equal(10, product.StockQuantity);
        Assert.True(product.IsActive);
        Assert.NotEqual(default, product.CreatedAt);
        Assert.NotEqual(default, product.UpdatedAt);
    }

    [Fact]
    public void Should_Throw_Exception_When_Name_Is_Empty(){

        var exception = Assert.Throws<DomainException>(() =>
            new Product(
                name: "",
                description: "Teclado mecanico com switches brown",
                price: 399.90m,
                stockQuantity: 10
            )
        );
        Assert.Equal("O nome do produto é obrigatório.", exception.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Price_Is_Zero()
    {
        var exception = Assert.Throws<DomainException>(() =>
            new Product(
                name: "Teclado mecanico",
                description: "Teclado mecanico com switches brown",
                price: 0,
                stockQuantity: 10
            )
        );
        Assert.Equal("O preço deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Price_Is_Negative()
    {
        var exception = Assert.Throws<DomainException>(() =>
            new Product(
                name: "Teclado mecanico",
                description: "Teclado mecanico com switches brown",
                price: -10,
                stockQuantity: 10
            )
        );

        Assert.Equal("O preço deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_StockQuantity_Is_Negative()
    {
        var exception = Assert.Throws<DomainException>(() =>
            new Product(
                name: "Teclado mecanico",
                description: "Teclado mecanico com switches brown",
                price: 399.90m,
                stockQuantity: -1
            )
        );

        Assert.Equal("O estoque não pode ser negativo.", exception.Message);
    }

    [Fact]
    public void Should_Change_Price_When_Price_Is_Valid()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.ChangePrice(499.90m);

        Assert.Equal(499.90m, product.Price);
    }

    [Fact]
    public void Should_Throw_Exception_When_Changing_Price_To_Zero()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.ChangePrice(0)
        );

        Assert.Equal("O preço deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Changing_Price_To_Negative()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.ChangePrice(-50)
        );

        Assert.Equal("O preço deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Increase_Stock_When_Quantity_Is_Valid()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.IncreaseStock(5);

        Assert.Equal(15, product.StockQuantity);
    }

    [Fact]
    public void Should_Throw_Exception_When_Increasing_Stock_With_Zero()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.IncreaseStock(0));

        Assert.Equal("A quantidade deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Increasing_Stock_With_Negative_Quantity()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.IncreaseStock(-5)
        );

        Assert.Equal("A quantidade deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Decrease_Stock_When_Quantity_Is_Available()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.DecreaseStock(4);

        Assert.Equal(6, product.StockQuantity);
    }

    [Fact]
    public void Should_Throw_Exception_When_Decreasing_Stock_With_Zero()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.DecreaseStock(0)
        );

        Assert.Equal("A quantidade deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Decreasing_Stock_With_Negative_Quantity()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.DecreaseStock(-5)
        );

        Assert.Equal("A quantidade deve ser maior que zero.", exception.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Decreasing_Stock_More_Than_Available()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.DecreaseStock(15)
        );

        Assert.Equal("Estoque insuficiente.", exception.Message);
    }

    [Fact]
    public void Should_Return_True_When_Product_Has_Available_Stock()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var hasAvailableStock = product.HasAvailableStock(5);

        Assert.True(hasAvailableStock);
    }

    [Fact]
    public void Should_Return_False_When_Product_Does_Not_Have_Enough_Stock()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var hasAvailableStock = product.HasAvailableStock(15);

        Assert.False(hasAvailableStock);
    }

    [Fact]
    public void Should_Return_False_When_Product_Is_Inactive()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.Deactivate();

        var hasAvailableStock = product.HasAvailableStock(5);

        Assert.False(hasAvailableStock);
    }

    [Fact]
    public void Should_Return_False_When_Checking_Available_Stock_With_Zero_Quantity()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var hasAvailableStock = product.HasAvailableStock(0);

        Assert.False(hasAvailableStock);
    }

    [Fact]
    public void Should_Return_False_When_Checking_Available_Stock_With_Negative_Quantity()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var hasAvailableStock = product.HasAvailableStock(-5);

        Assert.False(hasAvailableStock);
    }

    [Fact]
    public void Should_Deactivate_Product_When_Product_Is_Active()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.Deactivate();

        Assert.False(product.IsActive);
    }

    [Fact]
    public void Should_Throw_Exception_When_Deactivating_Product_Already_Inactive()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.Deactivate();

        var exception = Assert.Throws<DomainException>(() =>
            product.Deactivate()
        );

        Assert.Equal("Produto ja esta inativo.", exception.Message);
    }

    [Fact]
    public void Should_Activate_Product_When_Product_Is_Inactive()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.Deactivate();

        product.Activate();

        Assert.True(product.IsActive);
    }

    [Fact]
    public void Should_Throw_Exception_When_Activating_Product_Already_Active()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.Activate()
        );

        Assert.Equal("Produto ja esta ativo.", exception.Message);
    }

    [Fact]
    public void Should_Update_Product_Details_When_Data_Is_Valid()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        product.UpdateDetails(
            name: "Mouse sem fio",
            description: "Mouse ergonomico com bluetooth"
        );

        Assert.Equal("Mouse sem fio", product.Name);
        Assert.Equal("Mouse ergonomico com bluetooth", product.Description);
    }

    [Fact]
    public void Should_Throw_Exception_When_Updating_Details_With_Empty_Name()
    {
        var product = new Product(
            name: "Teclado mecanico",
            description: "Teclado mecanico com switches brown",
            price: 399.90m,
            stockQuantity: 10
        );

        var exception = Assert.Throws<DomainException>(() =>
            product.UpdateDetails(
                name: "",
                description: "Mouse ergonomico com bluetooth"
            )
        );

        Assert.Equal("O nome do produto é obrigatório.", exception.Message);
    }
}
