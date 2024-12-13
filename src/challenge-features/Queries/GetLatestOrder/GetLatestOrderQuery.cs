using MediatR;

namespace challenge_features.Queries.GetLatestOrder
{
    public class GetLatestOrderQuery: IRequest<OrderResponse>
    {
        public string User { get; set; }
        public string CustomerId { get; set; }
    }
}
