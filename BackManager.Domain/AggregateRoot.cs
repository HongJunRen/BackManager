using Mxlemon.Magic.Portal.DomainDrive;

namespace BackManager.Domain
{
    public class AggregateRoot : AggregateRoot<long>, IAggregateRoot, IDeleteEntity
    {
        
    }
    public class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
    {

    }
}