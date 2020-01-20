using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DsLine.Catalogs.Services.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseServiceProviderFactory(new AutofacServiceProviderFactory())
              .ConfigureContainer<ContainerBuilder>(builder =>
              {


                  builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                      .AsImplementedInterfaces();

                  //  builder.AddDispatchers();
                  builder.AddRabbitMq();
                  builder.Register(s => s.Resolve<IInstanceFactory>().Create());

              })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
