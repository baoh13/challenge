namespace challenge_features.Dtos
{
    public class CustomerDto
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
