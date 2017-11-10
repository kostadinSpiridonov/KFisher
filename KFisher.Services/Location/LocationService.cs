using KFisher.Data;
using KFisher.Entities;

namespace KFisher.Services
{
    public class LocationService : BaseService<Location>, ILocationService
    {
        public LocationService(IApplicationDbContext context)
            : base(context)
        {

        }
    }
}
