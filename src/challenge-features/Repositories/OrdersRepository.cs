using AutoFixture;
using challenge_features.Data;
using challenge_features.Models;

namespace challenge_features.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly Fixture _fixture;

        public OrdersRepository(ApplicationDbContext context)
        {
            _context = context;
            _fixture = new Fixture();
        }

        public Order AddOrder(Order order)
        {
            var orderObj = _context.Orders.Add(order);
            _context.SaveChanges();
            return orderObj.Entity;
        }

        public Order GetLatestOrder(string customerId)
        {
            var order = _context.Orders
                                .Where(o => o.CustomerId == customerId)
                                .OrderByDescending(o => o.OrderDate)
                                .SingleOrDefault();
            order.CustomerId = customerId;
            order.ContainsGift = true;

            return order;
        }
    }
}
