using Microsoft.EntityFrameworkCore;
using challenge_features.Data;
using challenge_features.Models;

namespace challenge_features.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersWithOrdersAsync()
        {
            var customers = await _context.Customers
                                          .Include(c => c.Orders)
                                          .ThenInclude(o => o.OrderItems)
                                          .ThenInclude(oi => oi.Product)
                                          .ToListAsync();

            foreach (var customer in customers)
            {
                customer.Orders = await _context.Orders
                                                .Where(o => o.CustomerId == customer.Id)
                                                .ToListAsync();
            }
       
            return customers;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
