using System.Text.Json.Serialization;

namespace challenge_features.Models.Requests
{
    public class GetCustomerDetailsRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
