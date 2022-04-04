using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABSA.Core.Service.Extensions
{
    public static class WebHostBuilderExtension
    {
        public static IWebHostBuilder AddBaseUrl(this IWebHostBuilder webHostBuilder)
        {
            return webHostBuilder.ConfigureServices(services => {
                var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
                var connection = config.GetSection("Route:BasePath");
                webHostBuilder.UseUrls(urls: connection.Value);
            });
        }
    }
}

