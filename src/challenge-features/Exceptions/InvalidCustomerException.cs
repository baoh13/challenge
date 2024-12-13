namespace challenge.Exceptions
{
    public class InvalidCustomerException: Exception
    {
        public InvalidCustomerException(string errorMessage = "Invalid Customer"): base(errorMessage)
        {            
        }
    }
}
