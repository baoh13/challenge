using AutoFixture;
using challenge.Exceptions;
using challenge_features.Models;
using challenge_features.Models.Responses;
using challenge_features.Queries.GetLatestOrder;
using challenge_features.Repositories;
using challenge_features.Services;
using Moq;

namespace challenge_features_tests.Services
{
    [TestFixture]
    public class OrdersServiceTests
    {
        private Fixture _fixture;
        private Order _order;
        private OrdersService _sut;
        private Mock<IOrdersRepository> _ordersRepository;
        private Mock<ICustomerDetailsService> _customerDetailsService;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _ordersRepository = new Mock<IOrdersRepository>();
            _customerDetailsService = new Mock<ICustomerDetailsService>();

            _order = _fixture.Create<Order>();
            
            _ordersRepository.Setup(o => o.GetLatestOrder(It.IsAny<string>()))
                             .Returns(_order);

            _sut = new OrdersService(_ordersRepository.Object, _customerDetailsService.Object);
        }

        [Test]
        public void It_Throws_InvalidCustomerException_WhilstGetCustomerDetails()
        {
            // TODO complete the test
        }

        [Test]
        public async Task It_GetCustomerDetails()
        {
            //TODO a complete test for GetCustomerDetails()
        }
    }
}
