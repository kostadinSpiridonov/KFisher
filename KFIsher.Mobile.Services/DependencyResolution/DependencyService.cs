using Ninject;

namespace KFIsher.Mobile.Services.DependencyResolution
{
    public static class DependencyService
    {
        /// <summary>
        /// Singleton instance of the kernel
        /// </summary>
        private static IKernel kernelInstance;

        /// <summary>
        /// Kernel access property
        /// </summary>
        private static IKernel Kernel
        {
            get
            {
                if (kernelInstance == null)
                {
                    kernelInstance = new StandardKernel();
                }

                return kernelInstance;
            }
        }

        /// <summary>
        /// Returns the instance of the T
        /// </summary>
        /// <typeparam name="T">Interface which is registered in the dependency bindings</typeparam>
        /// <returns></returns>
        public static T GetIntance<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
