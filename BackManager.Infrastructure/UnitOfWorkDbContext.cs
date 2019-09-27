using BackManager.Domain;
using BackManager.Utility;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWork
{
    public class UnitOfWorkDbContext : DbContext
    {
        public UnitOfWorkDbContext(DbContextOptions<UnitOfWorkDbContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(StaticConstraint.MySqlConnectionString);
        //}
        public DbSet<SysGroup> SysGroups { get; set; }
        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysUserGroup> SysUserGroups { get; set; }

        public DbSet<SysMenu> SysMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysGroup>()
                .ToTable("SysGroup")
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<SysUser>()
                .ToTable("SysUser")
                .Property(e => e.LoginName)
                .IsUnicode(false);

            modelBuilder.Entity<SysUserGroup>().ToTable("SysUserGroup");


            modelBuilder.Entity<SysMenu>().ToTable("SysMenu");


        }
    }
}