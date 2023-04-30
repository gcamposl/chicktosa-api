using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

            return services;
        }
    }
}