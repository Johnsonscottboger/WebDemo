using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;
using Web.DataAccess.Entities;

namespace Web.Data.Context
{
    public class MyContext :DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 多对多关系
            modelBuilder.Entity<User_Role>()
                .HasKey(p => new { p.UserId,p.RoleId });

            modelBuilder.Entity<User_Role>()
                .HasOne(p => p.User)
                .WithMany(u => u.User_Roles)
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<User_Role>()
                .HasOne(p => p.Role)
                .WithMany(r => r.User_Roles)
                .HasForeignKey(p => p.RoleId);
            #endregion
        }
    }
}
