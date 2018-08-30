using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Z2data.Web.APIs.Startup))]
namespace Z2data.Web.APIs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Map Dashboard to the `http://<your-app>/hangfire` URL.
            //app.UseHangfireDashboard();
        }
    }
}