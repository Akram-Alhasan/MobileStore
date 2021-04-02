using Microsoft.Extensions.DependencyInjection;
using MobileStore.Services.Catalog.Domain.Interfaces.IRepositories;
using MobileStore.Services.Catalog.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MobileStore.Services.Catalog.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            var assemblies = Assembly.GetExecutingAssembly();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
