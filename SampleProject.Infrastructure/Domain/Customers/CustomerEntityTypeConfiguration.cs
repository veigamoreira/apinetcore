using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleProject.Domain.Customers;
using SampleProject.Infrastructure.Database;

namespace SampleProject.Infrastructure.Domain.Customers
{
    internal sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            
            builder.HasKey(b => b.Id);

            builder.Property("_age").HasColumnName("Age");
            builder.Property("_name").HasColumnName("Name");
       
        }
    }
}