using Microsoft.EntityFrameworkCore;
using Web.Data.Entities;

namespace Web.Data.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
    }
}
