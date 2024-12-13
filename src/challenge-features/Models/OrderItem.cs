namespace challenge_features.Models
{
    public class OrderItem
    {
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool Returnable { get; set; }
        public Product Product { get; set; }
    }
}
