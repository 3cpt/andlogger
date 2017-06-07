namespace Andlogger
{
    using System;

    public class Log
    {
        public Log(Level level, string message)
        {
            this.Level = level;
            this.Message = message;
        }

        public Log(Level level, string message, Exception exception)
            : this(level, message)
        {
            this.Exception = exception;
        }

        public Level Level { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public DateTime Timestamp { get; private set; } = DateTime.Now;

        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}