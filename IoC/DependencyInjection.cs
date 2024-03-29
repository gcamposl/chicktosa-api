using Application.Mappings;
using Application.Services;
using Application.Services.Interfaces;
using Domain.Repositories;
using Data.Context;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Authentication;
using Data.Authentication;
using Domain.Integrations;
using Data.Integrations;

namespace IoC
{
    public static class DependencyInjection
    {

        // injetando depencia para infra
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // injetando service de database
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // injetando service de repository
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonImageRepository, PersonImageRepository>();
            services.AddScoped<ISavePersonImage, SavePersonImage>();

            return services;
        }

        // injetando depencia para services
        public static IServiceCollection AddService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DtoToDomainMapping));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonImageService, PersonImageService>();

            return services;
        }
    }
}