using Microsoft.EntityFrameworkCore;

namespace BackManager.Infrastructure
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}