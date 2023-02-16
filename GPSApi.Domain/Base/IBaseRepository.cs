namespace GPSApi.Domain.Base
{
    public interface IBaseRepository
    {
    }

    public interface IBaseRepository<TId, TEntity> : IBaseRepository where TEntity : BaseEntity<TId>
    {
        Task<TEntity> Get(TId Id);
    }
}