using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleProject.Domain.Customers.Orders
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(CustomerId id);

        Task AddAsync(Customer customer);

        Task<List<Customer>> GetAll();

        Task DeleteAsync(CustomerId id);
        Task<bool> Update(Customer customer);
    }
}