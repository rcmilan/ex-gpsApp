using GPSApi.Domain.Base;

namespace GPSApi.Domain.Entities
{
    public class PointOfInterest : BaseEntity<Guid>
    {
        public string Name { get; init; } = default!;
        public uint PointX { get; init; }
        public uint PointY { get; init; }
    }
}