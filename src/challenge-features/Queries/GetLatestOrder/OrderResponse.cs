using challenge_features.Dtos;

namespace challenge_features.Queries.GetLatestOrder
{
    public class OrderResponse
    {
        public CustomerDto Customer { get; set; }
        public OrderDto Order { get; set; }
    }
}