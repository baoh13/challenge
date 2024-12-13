using challenge_features.Models;

namespace challenge_features.Repositories
{
    public interface IOrdersRepository
    {
        Order AddOrder(Order order);
        Order GetLatestOrder(string customerId);
    }
}
