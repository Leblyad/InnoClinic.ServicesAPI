using Castle.Core.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ServicesAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ServicesAPI.Tests.Extensions
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //builder.ConfigureServices(services =>
            //{
            //    var dbContextDescriptor = services.SingleOrDefault(
            //        d => d.ServiceType ==
            //            typeof(DbContextOptions<ApplicationDbContext>));

            //    services.Remove(dbContextDescriptor);

            //    var dbConnectionDescriptor = services.SingleOrDefault(
            //        d => d.ServiceType ==
            //            typeof(DbConnection));

            //    services.Remove(dbConnectionDescriptor);

            //    // Create open SqliteConnection so EF won't automatically close it.
            //    services.AddSingleton<DbConnection>(container =>
            //    {
            //        var connection = new SqliteConnection("DataSource=:memory:");
            //        connection.Open();

            //        return connection;
            //    });

            //    services.ConfigureSqlContext()
            //});

            //builder.UseEnvironment("Development");
        }
    }
}
