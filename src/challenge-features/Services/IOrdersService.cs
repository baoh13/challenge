using challenge_features.Queries.GetLatestOrder;

namespace challenge_features.Services
{
    public interface IOrdersService
    {
        Task<OrderResponse> GetLastestOrderAsync(GetLatestOrderQuery query);
    }
}
