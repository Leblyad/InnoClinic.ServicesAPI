﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Repository;
using ServicesAPI.Core.Services;
using ServicesAPI.Core.Services.Abstractions;
using ServicesAPI.Infrastructure.Repository;

namespace InnoClinic.ServicesAPI.Tests.Configuration
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<RepositoryContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<RepositoryContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryServiceTest");
                });

                services.AddScoped<IServiceManager, ServiceManager>();
                services.AddScoped<IRepositoryManager, RepositoryManager>();

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())

                using (var appContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
                {
                    try
                    {
                        appContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });

            builder.UseEnvironment("Development");
        }
    }
}
