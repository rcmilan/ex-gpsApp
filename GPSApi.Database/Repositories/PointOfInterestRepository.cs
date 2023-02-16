using GPSApi.Database.Interfaces;
using GPSApi.Domain.Entities;

namespace GPSApi.Database.Repositories
{
    internal class PointOfInterestRepository : IPointOfInterestRepository
    {
        public Task<PointOfInterest> Get(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
