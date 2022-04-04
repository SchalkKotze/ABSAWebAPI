using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ABSA.Core.Service.Extensions;
using Serilog;
using Serilog.Events;

namespace ABSA.Core.Service
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {           
            try
            {
                string environmentName;

#if DEBUG
                environmentName = "Development";
#elif STAGING
                    environmentName = "Staging";
#elif RELEASE
                    environmentName = "Production";
#endif

               

                var builder = CreateWebHostBuilder(args, environmentName);

                var isService = !(Debugger.IsAttached || args.Contains("--console"));

                if (isService)
                {
                    var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                    var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                    builder.UseContentRoot(pathToContentRoot);
                }

                var webHost = builder.Build();

                if (isService)
                {
                    webHost.RunAsCustomService();
                }
                else
                {
                    await webHost.RunAsync();
                }

                return 0;
            }
            catch (Exception ex)
            {               
                return 1;
            }
            finally
            {
               
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, string environmentName) =>
            WebHost.CreateDefaultBuilder(args).
                UseEnvironment(environmentName).
                ConfigureAppConfiguration((env, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{env.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddEnvironmentVariables();
                    config.AddCommandLine(args);
                }).
                UseStartup<Startup>().
                AddBaseUrl().
                UseSerilog();

    }
}
