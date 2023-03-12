using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Item> Item { get; set; }
        public DbSet<User> User { get; set; }
    }
}
