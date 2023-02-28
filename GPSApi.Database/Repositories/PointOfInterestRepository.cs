using GPSApi.Database.Configuration;
using GPSApi.Database.Interfaces;
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

        public async Task<PointOfInterest> Get(Guid Id)
        {
            return await dbContext.Set<PointOfInterest>()
                .SingleOrDefaultAsync(p => p.Id == Id);
        }
    }
}