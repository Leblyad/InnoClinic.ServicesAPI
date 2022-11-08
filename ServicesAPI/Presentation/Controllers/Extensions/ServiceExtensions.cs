﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Repository;
using ServicesAPI.Core.Services;
using ServicesAPI.Core.Services.Abstractions;
using ServicesAPI.Infrastructure.Repository;
using ServicesAPI.Presentation.Middlewares;
using System.Net;

namespace ServicesAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
            opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
            b.MigrationsAssembly("ServicesAPI")));

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
