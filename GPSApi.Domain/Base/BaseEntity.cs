namespace GPSApi.Domain.Base
{
    public abstract class BaseEntity
    {
    }

    public abstract class BaseEntity<T> : BaseEntity
    {
        public T Id { get; init; } = default!;
    }
}