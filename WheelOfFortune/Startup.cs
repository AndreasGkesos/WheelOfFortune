using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector.Integration.Web.Mvc;
using WheelOfFortune.Models;
using WheelOfFortune.Repos.Interfaces;
using WheelOfFortune.Repos;
using WheelOfFortune.Services;

[assembly: OwinStartupAttribute(typeof(WheelOfFortune.Startup))]
namespace WheelOfFortune
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var container = InitializeSimpleInjector(app, config);
            ConfigureAuth(app);


            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        public static Container Register(Container container, ScopedLifestyle scopedLifestyle)
        {
            container.Options.DefaultScopedLifestyle = scopedLifestyle;
            container.Register(() => new ApplicationDbContext(), Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<ICouponRepo, CouponRepo>(Lifestyle.Scoped);
            container.Register<ICouponValueRepo, CouponValueRepo>(Lifestyle.Scoped);
            container.Register<IBalanceRepo, BalanceRepo>(Lifestyle.Scoped);
            container.Register<ISpinRepo, SpinRepo>(Lifestyle.Scoped);
            container.Register<ITransactionRepo, TransactionRepo>(Lifestyle.Scoped);
            container.Register<IWheelConfigurationRepo, WheelConfigurationRepo>(Lifestyle.Scoped);
            container.Register<IWheelConfigurationSliceRepo, WheelConfigurationSliceRepo>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<IWheelService, WheelService>(Lifestyle.Scoped);

            return container;
        }

        private static Container InitializeSimpleInjector(IAppBuilder app, HttpConfiguration config)
        {
            // Set WepApi DependencyResolver
            var container = new Container();
            var dependencyResolver = new SimpleInjectorDependencyResolver(container);


            Register(container, new WebApiRequestLifestyle());

            container.RegisterWebApiControllers(config);
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            return container;
        }
    }
}