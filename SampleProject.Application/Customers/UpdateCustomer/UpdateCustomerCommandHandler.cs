using System.Threading;
using System.Threading.Tasks;
using SampleProject.Application.Configuration.Commands;
using SampleProject.Domain.Customers;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Domain.SeedWork;

namespace SampleProject.Application.Customers.RegisterCustomer
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(
            ICustomerRepository customerRepository, 
            ICustomerUniquenessChecker customerUniquenessChecker, 
            IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            _customerUniquenessChecker = customerUniquenessChecker;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            CustomerId CustomerId = new CustomerId(request.Id);

            var costumer =  await this._customerRepository.GetByIdAsync(CustomerId);
            costumer._name = request.Name;
            costumer._age = request.Age;

            await this._unitOfWork.CommitAsync(cancellationToken);
            await this._customerRepository.Update(costumer);

            return new CustomerDto { Id = costumer.Id.Value };
        }
    }
}