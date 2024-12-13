namespace challenge.Exceptions
{
    public class ApiException: Exception
    {
        public ApiException(string error = "Api Client Exeption"): base(error) { }
    }
}
