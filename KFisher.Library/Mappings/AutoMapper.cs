using AutoMapper;
using System.Reflection;

namespace KFisher.Library.Mappings
{
    public class AutoMapper
    {
        public static void Configure()
        {
            var assembly = AutoMapper.GetAssembly();
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(assembly));
        }

        private static Assembly GetAssembly()
        {
            return typeof(AutoMapper).Assembly;
        }
    }
}
