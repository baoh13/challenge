using MediatR;
using challenge_features.Dtos;
using challenge_features.Models;
using challenge_features.Repositories;

namespace challenge_features.Queries.GetCustomerWithOrders
{
    public class GetCustomersWithOrdersQueryHandler(ICustomerRepository customerRepository)
        : IRequestHandler<GetCustomersWithOrdersQuery, GetCustomersWithOrdersResponse>
    {
        public async Task<GetCustomersWithOrdersResponse> Handle(GetCustomersWithOrdersQuery request, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.GetCustomersWithOrdersAsync();

            var customerDtos = GetCustomerDtos(customers);

            var response = new GetCustomersWithOrdersResponse()
            {
                Customers = customerDtos
            };

            return response;
        }

        private List<CustomerDto> GetCustomerDtos(List<Customer> customers)
        {
            return customers.Select(customer => new CustomerDto
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Orders = customer.Orders.Select(order => new OrderDto
                {
                    DeliveryAddress = order.DeliveryAddress,
                    OrderDate = order.OrderDate.ToString("dd-MMMM-yyyy"),
                    OrderNumber = order.OrderId,
                    DeliveryExpected = order.DeliveryExpected.ToString("dd-MMMM-yyyy"),
                    OrderItems = order.OrderItems.Select(item => new OrderItemDto
                    {
                        Price = item.Price,
                        Quantity = item.Quantity,
                        Product = item.Product.ProductName
                    }).ToList()
                }).ToList()
            }).ToList();
        }
    }
}
