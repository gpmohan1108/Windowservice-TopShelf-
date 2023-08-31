﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DotNet_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {

           Configureservice.Configure();
        }
    }
    public class Configureservice
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<myservice>(service =>
                {
                    service.ConstructUsing(s => new myservice());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("WinServiceWithTopshelf");
                configure.SetDisplayName("WinServiceWithTopshelf");
                configure.SetDescription("WinService With Topshelf");
            });
        }
    }
}
