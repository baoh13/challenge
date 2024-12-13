namespace challenge.Exceptions
{
    public class InvalidOrderRequest: Exception
    {
        public InvalidOrderRequest(string errorMessage = "Invalid User Email Address")
            : base(errorMessage) 
        { }
    }
}
