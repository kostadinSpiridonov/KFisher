using AutoMapper;

namespace KFisher.Library.Mappings
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            var assembly = typeof(AutoMapperConfig)?.Assembly;
            Mapper.Initialize(cfg => cfg.AddProfiles(assembly));
        }
    }
}
