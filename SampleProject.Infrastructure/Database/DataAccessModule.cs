using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleProject.Application.Configuration.Data;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Domain.SeedWork;
using SampleProject.Infrastructure.Domain;
using SampleProject.Infrastructure.Domain.Customers;
using SampleProject.Infrastructure.SeedWork;

namespace SampleProject.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();


            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();
          

            builder.RegisterType<StronglyTypedIdValueConverterSelector>()
                .As<IValueConverterSelector>()
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<Context>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new Context(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}