using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MobileStore.Services.Catalog.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var assemblies = Assembly.GetExecutingAssembly();
            services.AddMediatR(assemblies);
            return services;
        }
    }
}
