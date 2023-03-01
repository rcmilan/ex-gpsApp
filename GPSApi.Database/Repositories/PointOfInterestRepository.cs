using GPSApi.Database.Configuration;
using GPSApi.Database.Interfaces;
using GPSApi.Domain.Base;
using GPSApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPSApi.Database.Repositories
{
    internal class PointOfInterestRepository : IPointOfInterestRepository
    {
        private readonly MyDbContext dbContext;

        public PointOfInterestRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Guid> Add(PointOfInterest entity)
        {
            dbContext.Set<PointOfInterest>();

            dbContext.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public Task<PointOfInterest> Get(Guid Id)
            => dbContext.Set<PointOfInterest>().SingleOrDefaultAsync(p => p.Id == Id);

        public async Task<IReadOnlyCollection<PointOfInterest>> GetInRadius(uint x, uint y)
        {
            var radius = Constants.RADIUS;

            // ToDo: criar uma função decente

            return await dbContext.Set<PointOfInterest>()
                .Where(p => p.PointX >= x - radius && p.PointX <= x + radius)
                .Where(p => p.PointY >= y - radius && p.PointY <= y + radius)
                .ToListAsync();
        }
    }
}