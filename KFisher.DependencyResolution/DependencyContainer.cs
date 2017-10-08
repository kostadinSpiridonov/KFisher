﻿using KFisher.Data;
using KFisher.Services;
using KFishers.Managers;
using KFishers.Managers.Security;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace KFisher.DependencyResolution
{
    public static class DependencyContainer
    {
        private static Container container;

        public static Container Container
        {
            get
            {
                return container;
            }
        }

        public static void ConfigureContainer(HttpConfiguration configuration)
        {
            container = new Container();

            SetBaseContainerSettings();
            RegisterDataAccess();
            RegisterBusinessLogic();
            RegisterDatabase();
            RegisterWebApiControllers();

            container.Verify();

        }

        private static void SetBaseContainerSettings()
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        private static void RegisterDataAccess()
        {
            container.Register<IAuthenticationService, AuthenticationService>();
        }

        private static void RegisterBusinessLogic()
        {
            container.Register<IAuthenticationManager, AuthenticationManager>();
            container.Register<IHashGenerator, HashGenerator>();
        }

        private static void RegisterDatabase()
        {
            container.RegisterSingleton<IApplicationDbContext>(new ApplicationDbContext());
        }

        private static void RegisterWebApiControllers()
        {
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
        }
    }
}
