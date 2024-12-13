using challenge_features.Models.Responses;

namespace challenge_features.Services
{
    public interface ICustomerDetailsService
    {        
        Task<CustomerDetailsResponse> GetCustomerDetailsAsync(string customerEmail);
    }
}
