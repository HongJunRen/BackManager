namespace BackManager.Domain
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
