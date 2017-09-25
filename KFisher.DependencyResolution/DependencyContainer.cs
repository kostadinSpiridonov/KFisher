using KFisher.Services;
using KFishers.Managers;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace KFisher.DependencyResolution
{
    public static class DependencyContainer
    {
        public static Container GetContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IAuthenticationService, AuthenticationService>();
            container.Register<IAuthenticationManager, KFishers.Managers.AuthenticationManager>();
            container.Register<IAuthenticationService, AuthenticationService>();

            return container;
        }
    }
}
