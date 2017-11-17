using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminMonitorApp.Startup1))]
namespace AdminMonitorApp
{
    public partial class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
