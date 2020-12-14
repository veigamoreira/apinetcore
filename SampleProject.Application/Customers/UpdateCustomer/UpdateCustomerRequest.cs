using System;

namespace SampleProject.Application.Customers.RegisterCustomer
{
    public class UpdateCustomerRequest
    {
        public string Age { get; set; }

        public string Name { get; set; }

        public Guid Id { get; set; }

    }
}