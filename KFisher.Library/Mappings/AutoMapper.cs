using AutoMapper;

namespace KFisher.Library.Mappings
{
    public class AutoMapper
    {
        public static void Configure()
        {
            var assembly = typeof(AutoMapper)?.Assembly;
            Mapper.Initialize(cfg => cfg.AddProfiles(assembly));
        }
    }
}
