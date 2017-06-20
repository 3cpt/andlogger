namespace Andlogger
{
    using System;

    public interface ILog
    {
        void Debug(string message);

        void Debug(string message, Exception exception);

        void Info(string message);

        void Warning(string message);

        void Error(string message);

        void Error(string message, Exception exception);
    }
}