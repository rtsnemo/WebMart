using Application.Abstractions.Categories;
using Application.Abstractions.Customers;
using Application.Abstractions.Products;
using Application.Abstractions.Reviews;
using Application.Abstractions.Users;
using Application.MediatR.Categories.QueryHandlers;
using Application.MediatR.Products.Queries;
using Application.MediatR.Products.QueryHandlers;
using Application.MediatR.Reviews.QueryHandlers;
using Application.MediatR.Users.CommandHandlers;
using Application.MediatR.Users.Queries;
using Infrastructure.Repositories;
using Infrastructure.Services.Users;
using System.Reflection;

namespace WebApi.Configuration
{
    public static class ConfigureExtension
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IJWTGeneratorService, JWTGeneratorService>();
            builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(GetAllCategories))));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(GetProductsByCategory))));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(CreateUser))));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(GetUserById))));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(SignInUser))));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(GetAllProducts))));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(GetProductById))));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(GetReviewsByProduct))));

        }
    }
}
