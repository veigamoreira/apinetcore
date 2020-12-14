using SampleProject.Application.Customers.RegisterCustomer;
using System.Reflection;

namespace SampleProject.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(RegisterCustomerCommand).Assembly;
    }
}