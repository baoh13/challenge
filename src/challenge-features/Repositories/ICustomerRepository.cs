using challenge_features.Models;

namespace challenge_features.Repositories
{
    public interface ICustomerRepository
    {
        Task UpdateCustomerAsync(Customer customer);
        Task<List<Customer>> GetCustomersWithOrdersAsync();
    }
}
