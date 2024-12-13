namespace challenge_features.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; }
        public string ShippingMode { get; set; }
        public string OrderSource { get; set; }
        public string DeliveryAddress { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
