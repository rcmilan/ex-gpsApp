namespace GPSApi.Domain.Base
{
    public interface IBaseRepository
    {
    }

    public interface IBaseRepository<TId, TEntity> : IBaseRepository where TEntity : BaseEntity<TId>
    {
        Task<TId> Add(TEntity entity);

        Task<TEntity> Get(TId Id);
    }
}