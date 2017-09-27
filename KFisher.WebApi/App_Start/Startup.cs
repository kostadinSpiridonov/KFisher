using KFisher.DependencyResolution;
using KFisher.Library.Mappings;
using KFisher.WebApi.App_Start;
using KFisher.WebApi.App_Start.Providers;
using KFishers.Managers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Startup))]

namespace KFisher.WebApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapper.Configure();

            var container = DependencyContainer.GetContainer();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            ConfigureOAuth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseWebApi(config);


            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var authManager = DependencyContainer.GetContainer().GetInstance<IAuthenticationManager>();
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(authManager)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                Provider = new OAuthBearerAuthenticationProvider()
            });
        }
    }
}