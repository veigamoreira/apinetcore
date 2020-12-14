using System.Threading;
using System.Threading.Tasks;
using SampleProject.Application.Configuration.Commands;
using SampleProject.Domain.Customers;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Domain.SeedWork;

namespace SampleProject.Application.Customers.DeleteCustomer
{
        public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, CustomerDto> { 


        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(
            ICustomerRepository customerRepository, 
            ICustomerUniquenessChecker customerUniquenessChecker, 
            IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            _customerUniquenessChecker = customerUniquenessChecker;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            CustomerId CustomerId = new CustomerId(request.Id);

            await this._customerRepository.DeleteAsync(CustomerId);

            await this._unitOfWork.CommitAsync(cancellationToken);

            return new CustomerDto {};
        }
    }
}