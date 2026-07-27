using Ecommerce.Application.UseCases.Products.CreateProduct;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Extensions;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();

        return services;
    }
}