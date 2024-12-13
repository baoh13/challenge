using challenge.Exceptions;
using challenge_features.Dtos;
using challenge_features.Models;
using challenge_features.Models.Responses;
using challenge_features.Queries.GetLatestOrder;
using challenge_features.Repositories;

namespace challenge_features.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ICustomerDetailsService _customerDetailsService;

        public OrdersService(
            IOrdersRepository ordersRepository, 
            ICustomerDetailsService customerDetailsService)
        {
            _ordersRepository = ordersRepository;
            _customerDetailsService = customerDetailsService;
        }

        public async Task<OrderResponse> GetLastestOrderAsync(GetLatestOrderQuery query)
        {
            var expectedOrder = _ordersRepository.GetLatestOrder(query.CustomerId);

            var userEmailAddress = query.User;
            var customerDetails = await _customerDetailsService.GetCustomerDetailsAsync(userEmailAddress);

            if (userEmailAddress != customerDetails.Email)
            {
                throw new InvalidCustomerException();
            }

            var orderDto = GetOrder(expectedOrder, customerDetails);

            var orderResponse = new OrderResponse
            {
                Customer = new CustomerDto
                {
                    FirstName = customerDetails.FirstName,
                    LastName = customerDetails.LastName
                },
                Order = orderDto
            };

            return orderResponse;
        }

        private OrderDto GetOrder(Order expectedOrder, CustomerDetailsResponse customerDetails)
        {
            OrderDto order;

            if (expectedOrder == null)
            {
                order = new OrderDto();
            }
            else
            {
                order = new OrderDto
                {
                    DeliveryAddress = $"{customerDetails.HouseNumber} {customerDetails.Street}, {customerDetails.Town}, {customerDetails.Postcode}",
                    OrderNumber = expectedOrder.OrderId,
                    OrderDate = expectedOrder.OrderDate.ToString("dd-MMMM-yyyy"),
                    DeliveryExpected = expectedOrder.DeliveryExpected.ToString("dd-MMMM-yyyy"),
                    OrderItems = expectedOrder.OrderItems.Select(i => new OrderItemDto
                    {
                        Price = i.Price,
                        Quantity = i.Quantity,
                        Product = i.Product.ProductName
                    }).ToList()
                };
            }

            return order;
        }
    }
}
