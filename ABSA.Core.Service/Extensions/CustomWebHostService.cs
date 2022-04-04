using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ABSA.Core.Service.Extensions
{
    [DesignerCategory("Code")]
    public class CustomWebHostService : WebHostService
    {
        public CustomWebHostService(IWebHost host) : base(host)
        {
        }

        protected override void OnStarting(string[] args)
        {           
            base.OnStarting(args);
        }

        protected override void OnStarted()
        {          
            base.OnStarted();
        }

        protected override void OnStopping()
        {           
            base.OnStopping();
        }
    }
}

