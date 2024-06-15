using System.Diagnostics;

namespace AuthenticationService
{
    public class Logger : ILogger
    {
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private string logDirectory { get; set; }

        public Logger() 
        {
            logDirectory = AppDomain.CurrentDomain.BaseDirectory + @"/_log/" + DateTime.Now.ToString("dd-MM-yy HH-mm-ss") + @"/";

            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);
        }
        public void WriteEvent(string eventMessage)
        {
            _lock.EnterWriteLock();
            try
            {
                using(StreamWriter writer = new StreamWriter(logDirectory + "even.txt", append: true))
                {
                    Console.Write(eventMessage);
                }
            }
            finally { _lock.ExitWriteLock(); }
        }

        public void WriteError(string errorMessage) 
        {
            _lock.EnterWriteLock();
            try
            {
                using(StreamWriter writer = new StreamWriter("error.txt", append: true))
                {
                    Console.Write(errorMessage);
                }
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
