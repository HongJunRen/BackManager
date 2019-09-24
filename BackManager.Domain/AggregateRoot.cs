namespace BackManager.Domain
{
    public class AggregateRoot : AggregateRoot<long>, IAggregateRoot
    {
        
    }
    public class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
    {

    }
}