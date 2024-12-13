using challenge.Exceptions;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace challenge_features.Common.Api
{
    public class ApiClient(HttpClient httpClient): IApiClient
    {
        private HttpClient CreateHttpClient() => new HttpClient();

        public async Task<TResponse> PostAsync<TResponse, TPayload>(string uri, TPayload payload)
            where TResponse : class
            where TPayload : class
        {
            var client = CreateHttpClient();
            var customerDetailsJson = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                Application.Json);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, uri);
            httpRequest.Content = customerDetailsJson;

            using var response = await client.SendAsync(httpRequest);

            // Handle Unsuccessful requests
            if (response.StatusCode is HttpStatusCode.NotFound)
                throw new ApiNotFoundException();

            response.EnsureSuccessStatusCode();

            var customerDetails = await response.Content.ReadFromJsonAsync<TResponse>();

            return customerDetails;
        }
    }
}

