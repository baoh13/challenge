namespace challenge_features.Dtos
{
    public class OrderDto
    {
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryExpected { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
