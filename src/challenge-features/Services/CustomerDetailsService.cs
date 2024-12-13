using AutoFixture;
using challenge_features.Common.Api;
using challenge_features.Models.Requests;
using challenge_features.Models.Responses;

namespace challenge_features.Services
{
    public class CustomerDetailsService : ICustomerDetailsService
    {
        private readonly Fixture _fixture;
        private readonly IApiClient _apiClient;

        public CustomerDetailsService(IApiClient apiClient)
        {
            _fixture = new Fixture();
            _apiClient = apiClient;
        }

        public async Task<CustomerDetailsResponse> GetCustomerDetailsAsync(string customerEmail)
        {
            var uri = "api/GetUserDetails";
            var request = new GetCustomerDetailsRequest { Email = customerEmail };

            var customerDetails = await _apiClient.PostAsync<CustomerDetailsResponse, GetCustomerDetailsRequest>(uri, request);

            customerDetails.Email = customerEmail;

            return customerDetails;
        }
    }
}
