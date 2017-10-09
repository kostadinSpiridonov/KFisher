using KFisher.Mobile.Database.Services;
using Ninject.Modules;

namespace KFisher.Mobile.DependencyResolution
{
    public class LocalServicesModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel
        /// </summary>
        public override void Load()
        {
            this.BindServices();
        }

        /// <summary>
        /// Bind interfaces
        /// </summary>
        private void BindServices()
        {
            Bind<IAuthenticationServiceLS>().To<AuthenticationServiceLS>();
        }
    }
}
