namespace challenge_features.Common.Api
{
    public interface IApiClient
    {
        Task<TResponse> PostAsync<TResponse, TPayload>(string uri, TPayload payload)
            where TResponse : class
            where TPayload : class;
    }
}
