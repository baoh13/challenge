using MediatR;
using challenge_features.Services;

namespace challenge_features.Queries.GetLatestOrder
{
    public class GetLatestOrderQueryHandler(IOrdersService ordersService)
        : IRequestHandler<GetLatestOrderQuery, OrderResponse>
    {
        public async Task<OrderResponse> Handle(GetLatestOrderQuery request, CancellationToken cancellationToken)
        {
            var response = await ordersService.GetLastestOrderAsync(request);

            return response;
        }
    }
}
