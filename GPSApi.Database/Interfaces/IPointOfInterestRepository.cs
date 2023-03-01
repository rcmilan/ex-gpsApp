using GPSApi.Domain.Base;
using GPSApi.Domain.Entities;

namespace GPSApi.Database.Interfaces
{
    public interface IPointOfInterestRepository : IBaseRepository<Guid, PointOfInterest>
    {
    }
}