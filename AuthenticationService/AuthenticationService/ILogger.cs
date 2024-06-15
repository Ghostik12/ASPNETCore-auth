namespace AuthenticationService
{
    public interface ILogger
    {
        void WriteError(string errorMessage);
        void WriteEvent(string eventMessage);
    }
}
