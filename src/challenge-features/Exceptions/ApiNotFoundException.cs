namespace challenge.Exceptions
{
    public class ApiNotFoundException: ApiException
    {
        public ApiNotFoundException(string error = "Api Client Not Exeption"): base(error) { }
    }
}
