using api.application;
using api.domain;

namespace api.infra;

public static class DependencyContainer
{
    public static void AddInfra(this IServiceCollection services)
    {
        services.AddTransient<ProductValidations>();
        services.AddTransient<ICreateProductOperation, CreateProductOperation>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICreateProductDecorator, CreateProductDecorator>();
    }
}