using System.Threading;
using System.Threading.Tasks;
using SampleProject.Application.Configuration.Data;
using SampleProject.Application.Configuration.Queries;
using SampleProject.Domain.Customers;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Domain.SeedWork;

namespace SampleProject.Application.Customers.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IQueryHandler<GetCustomerDetailsQuery, CustomerDetailsDto>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerUniquenessChecker _customerUniquenessChecker;
        private readonly IUnitOfWork _unitOfWork;


        public GetCustomerDetailsQueryHandler(
            ICustomerRepository customerRepository,
            ICustomerUniquenessChecker customerUniquenessChecker,
            IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            _customerUniquenessChecker = customerUniquenessChecker;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerDetailsDto> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {

            CustomerId CustomerId = new CustomerId(request.CustomerId);

            var customer = await this._customerRepository.GetByIdAsync(CustomerId);

            await this._unitOfWork.CommitAsync(cancellationToken);

            return new CustomerDetailsDto { Id = customer.Id.Value, Age = customer._age, Name = customer._name };

        }
    }
}