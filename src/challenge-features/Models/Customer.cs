namespace challenge_features.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
