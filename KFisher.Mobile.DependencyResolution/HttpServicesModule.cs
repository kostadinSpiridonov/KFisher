using KFIsher.Mobile.Services.Connection;
using KFIsher.Mobile.Services.Services;
using Ninject.Modules;

namespace KFisher.Mobile.DependencyResolution
{
    public class HttpServicesModule : NinjectModule
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
            Bind<IHttpConnection>().To<HttpConnection>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
