using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Customers;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Infrastructure.Database;

namespace SampleProject.Infrastructure.Domain.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Customer customer)
        {
            await this._context.Customers.AddAsync(customer);
        }

        public async Task DeleteAsync(CustomerId id)
        {
            var customomer = await this.GetByIdAsync(id);
            this._context.Customers.Remove(customomer);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await this._context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(CustomerId id)
        {
            return await this._context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<bool> Update(Customer customer)
        {
            this._context.Customers.Update(customer);
            return true;
        }
    }
}