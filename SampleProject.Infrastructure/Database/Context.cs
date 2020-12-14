using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Customers;

namespace SampleProject.Infrastructure.Database
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }
    }
}
