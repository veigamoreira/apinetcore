using System;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Application.Customers.RegisterCustomer
{
    public class UpdateCustomerCommand : CommandBase<CustomerDto>
    {
        public string Age { get; }

        public string Name { get; }

        public Guid Id { get; }


        public UpdateCustomerCommand(string age, string name, Guid id)
        {
            this.Age = age;
            this.Name = name;
            this.Id = id;
        }      
    }
}