using AutoMapper;
using KFisher.Library.Helpers;

namespace KFisher.Library.Mappings
{
    public class AutoMapper
    {
        public static void Configure()
        {
            var assembly = AssemblyHelper.GetAssemblyByTypeName(nameof(AutoMapper));
            Mapper.Initialize(cfg => cfg.AddProfiles(assembly));
        }
    }
}
