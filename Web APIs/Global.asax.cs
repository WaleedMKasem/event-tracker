using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Microsoft.ApplicationInsights.Extensibility;
using Z2data.Web.APIs.Infrastructure;


namespace Z2data.Web.APIs
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Debug.WriteLine("....................App Started....................");
            DisableApplicationInsightsOnDebug();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // register dependencies
            var container = DependencyRegistrar.Register();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // hanghire
            //HangfireServer.Start(container);


        }

        /// <summary>
        /// to dispose the hangfire server (shut down)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {
            //HangfireServer.Dispose();
        }
        [Conditional("DEBUG")]
        private static void DisableApplicationInsightsOnDebug()
        {
            TelemetryConfiguration.Active.DisableTelemetry = true;
        }

    }
}
