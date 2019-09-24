namespace BackManager.Domain
{
    public interface IAggregateRoot : IAggregateRoot<long>, IEntity
    {

    }

    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
    {

    }
}