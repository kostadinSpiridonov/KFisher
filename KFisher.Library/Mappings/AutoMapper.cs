using AutoMapper;
using System.Reflection;

namespace KFisher.Library.Mappings
{
    public class AutoMapper
    {
        public static void Configure()
        {
            var assemblyName = AutoMapper.GetAssemblyName();
            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[] { assemblyName }));
        }

        private static string GetAssemblyName()
        {
            return AssemblyName.GetAssemblyName(Assembly.GetExecutingAssembly().FullName).Name;
        }
    }
}
