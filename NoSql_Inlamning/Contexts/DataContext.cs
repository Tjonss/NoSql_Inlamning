using Microsoft.EntityFrameworkCore;
using NoSql_Inlamning.Models.Entities;

namespace NoSql_Inlamning.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().ToContainer("Products").HasPartitionKey(x => x.PartitionKey);
        }
    }
}
