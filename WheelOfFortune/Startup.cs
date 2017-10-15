using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WheelOfFortune.Startup))]
namespace WheelOfFortune
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
