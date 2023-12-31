﻿using LogToElasticsearch.Data;
using LogToElasticsearch.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LogToElasticsearch.Installers
{
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(item => item.UseSqlServer(configuration.GetConnectionString("Db")));

            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes()
                .Where(type => type.IsClass
                    && !type.IsAbstract
                    && type.GetInterfaces()
                        .Any(i => i.IsGenericType
                                && i.GetGenericTypeDefinition() == typeof(IRepository<>)));

            foreach (var type in types)
            {
                foreach (var iface in type.GetInterfaces())
                {
                    services.AddScoped(iface, type);
                }
            }
        }
    }
}
