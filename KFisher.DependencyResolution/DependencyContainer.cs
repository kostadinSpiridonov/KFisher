using KFisher.Services;
using KFishers.Managers;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace KFisher.DependencyResolution
{
    public static class DependencyContainer
    {
        private static Container container { get; set; }

        public static Container GetContainer()
        {
            if (container == null)
            {
                container = new Container();
            }

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IAuthenticationService, AuthenticationService>(Lifestyle.Singleton);
            container.Register<IAuthenticationManager, KFishers.Managers.AuthenticationManager>(Lifestyle.Singleton);
            container.Register<IAuthenticationService, AuthenticationService>(Lifestyle.Singleton);

            return container;
        }
    }
}
