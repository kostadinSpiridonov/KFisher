using KFisher.DependencyResolution;
using KFisher.Library.Mappings;
using KFisher.WebApi.App_Start;
using KFisher.WebApi.App_Start.Providers;
using KFishers.Managers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
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
            ConfigureDependecyContainer();
            RegisterConfigs();
            ConfigureWebApi(app);
            ConfigureOAuth(app);
        }

        private void ConfigureDependecyContainer()
        {
            DependencyContainer.ConfigureContainer(GlobalConfiguration.Configuration);
        }

        private void RegisterConfigs()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapper.Configure();
        }

        private void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration()
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DependencyContainer.Container)
            };

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            var authManager = DependencyResolution.DependencyContainer.Container.GetInstance<IAuthenticationManager>();
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/authenticate"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                Provider = new SimpleAuthorizationServerProvider(authManager)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                Provider = new OAuthBearerAuthenticationProvider()
            });
        }
    }
}