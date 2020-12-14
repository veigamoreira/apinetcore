using System;
using SampleProject.Application.Configuration.Commands;

namespace SampleProject.Application.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand : CommandBase<CustomerDto>
    {
        public Guid Id { get; }

        public DeleteCustomerCommand(Guid Id)
        {
            this.Id = Id;
            
        }      
    }
}