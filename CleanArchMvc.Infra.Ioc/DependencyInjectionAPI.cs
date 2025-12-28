using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.Ioc
{
    public static class DependencyInjectionAPI
    {

        public static IServiceCollection AddInfrastrutureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // Identity Configuration
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // Authentication Service
            services.AddScoped<IAuthenticate, AuthenticateService>();

            // Modern AutoMapper registration: scan the assembly for profiles
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly);

            // MediatR Configuration: scan the assembly for handlers
            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));

            return services;
        }
    }
}
