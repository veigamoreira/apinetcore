using SampleProject.Domain.SeedWork;
using System;

namespace SampleProject.Domain.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        public CustomerId Id { get; private set; }

        public string _age { get; set; }

        public string _name { get; set; }


        private bool _welcomeEmailWasSent;

        private Customer()
        {
        }

        private Customer(string idade, string name)
        {
            this.Id = new CustomerId(Guid.NewGuid());
            _age = idade;
            _name = name;

            this.AddDomainEvent(new CustomerRegisteredEvent(this.Id));
        }

        public static Customer CreateRegistered(
            string email,
            string name,
            ICustomerUniquenessChecker customerUniquenessChecker)
        {

            return new Customer(email, name);
        }
    }
}