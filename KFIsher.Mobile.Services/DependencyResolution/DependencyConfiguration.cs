using KFIsher.Mobile.Services.Services;
using Ninject.Modules;

namespace KFIsher.Mobile.Services.DependencyResolution
{
    public class DependencyConfiguration : NinjectModule
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
            Bind<IUserService>().To<UserService>();
        }
    }
}
