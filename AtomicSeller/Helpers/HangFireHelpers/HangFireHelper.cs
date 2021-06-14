using Hangfire;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//https://serverfault.com/questions/590865/how-can-i-warm-up-my-asp-net-mvc-webapp-after-an-app-pool-recycle
//https://docs.microsoft.com/en-us/iis/get-started/whats-new-in-iis-8/iis-80-application-initialization 

namespace AtomicSeller
{
    public class HangFireHelper
    {
        /*
        public class ApplicationPreload : System.Web.Hosting.IProcessHostPreloadClient
        {
            public void Preload(string[] parameters)
            {
                HangfireBootstrapper.Instance.Start();
            }
        }

        public class HangfireBootstrapper : IRegisteredObject
        {
            public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();

            private readonly object _lockObject = new object();
            private bool _started;

            private BackgroundJobServer _backgroundJobServer;

            private HangfireBootstrapper()
            {
            }

            public void Start()
            {
                lock (_lockObject)
                {
                    if (_started) return;
                    _started = true;

                    HostingEnvironment.RegisterObject(this);

                    GlobalConfiguration.Configuration
                        .UseSqlServerStorage("connection string");
                    // Specify other options here

                    _backgroundJobServer = new BackgroundJobServer();
                }
            }

            public void Stop()
            {
                lock (_lockObject)
                {
                    if (_backgroundJobServer != null)
                    {
                        _backgroundJobServer.Dispose();
                    }

                    HostingEnvironment.UnregisterObject(this);
                }
            }

            void IRegisteredObject.Stop(bool immediate)
            {
                Stop();
            }
        }
        */

    }
}
