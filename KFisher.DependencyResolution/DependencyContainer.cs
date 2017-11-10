using KFisher.Data;
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
            container.Register<IUserService, UserService>();
            container.Register<ICommentService, CommentService>();
            container.Register<IStoryService, StoryService>();
            container.Register<ILocationService, LocationService>();
        }

        private static void RegisterBusinessLogic()
        {
            container.Register<IAuthenticationManager, AuthenticationManager>();
            container.Register<IUserManager, UserManager>();
            container.Register<IHashGenerator, HashGenerator>();
            container.Register<ICommentManager, CommentManager>();
            container.Register<IStoryManager, StoryManager>();
            container.Register<ILocationManager, LocationManager>();
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
