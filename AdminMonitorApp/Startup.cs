using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminMonitorApp.Startup))]
namespace AdminMonitorApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
