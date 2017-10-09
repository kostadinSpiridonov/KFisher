using KFisher.Mobile.DependencyResolution;
using Ninject;

namespace KFisher.DependencyLocator
{
    public static class DependencyLocator
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
                    kernelInstance = new StandardKernel(new HttpServicesModule(), new LocalServicesModule());
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
