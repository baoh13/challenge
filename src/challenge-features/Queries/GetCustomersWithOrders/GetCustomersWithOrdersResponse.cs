using challenge_features.Dtos;

namespace challenge_features.Queries.GetCustomerWithOrders
{
    public class GetCustomersWithOrdersResponse
    {
        public List<CustomerDto> Customers { get; set; }
    }
}
