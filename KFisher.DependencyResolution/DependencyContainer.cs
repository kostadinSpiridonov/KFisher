using KFisher.Data;
using KFisher.Services;
using KFishers.Managers;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace KFisher.DependencyResolution
{
    public static class DependencyContainer
    {
        private static Container container { get; set; }

        public static bool IsCreated { get; set; }
        public static Container GetContainer()
        {
            if (container == null)
            {
                IsCreated = true;
                container = new Container();
                container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
                container.Register<IAuthenticationService, AuthenticationService>();
                container.Register<IAuthenticationManager, AuthenticationManager>();
                container.RegisterSingleton<IApplicationDbContext>(new ApplicationDbContext());
            }


            return container;
        }
    }
}
