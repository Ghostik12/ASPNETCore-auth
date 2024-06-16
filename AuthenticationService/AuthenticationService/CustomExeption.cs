namespace AuthenticationService
{
    public class CustomExeption : Exception
    {
        public CustomExeption(string message) 
        {
            var error = new Exception(message);
        }
    }
}
