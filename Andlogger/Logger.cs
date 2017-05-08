using System;
using Andlogger.Strategies;

namespace Andlogger
{
    public class Logger : ILog
    {
        private IStrategy strategy;

        public Logger(Level level, string path, string extension = ".txt")
        {
            this.strategy = new FileLog(level, path, extension);
        }

        public Logger(Level level, string path)
        {
            this.strategy = new JsonLog(level, path);
        }

        public void Debug(string message)
        {
            this.strategy.Save(
                Level.Debug,
                Helpers.FormatedDate() + "|DEBUG|" + message);
        }

        public void Debug(string message, Exception exception)
        {
            this.strategy.Save(
                Level.Debug,
                Helpers.FormatedDate() + "|DEBUG|" + message + "\n>>>TRACE>>>" + exception.Message + ">>>" + exception.StackTrace);
        }

        public void Info(string message)
        {
            this.strategy.Save(
                Level.Info,
                Helpers.FormatedDate() + "|INFO|" + message);
        }

        public void Warning(string message)
        {
            this.strategy.Save(
                Level.Info,
                Helpers.FormatedDate() + "|WARNING|" + message);
        }

        public void Error(string message)
        {
            this.strategy.Save(
                Level.Info,
                Helpers.FormatedDate() + "|ERROR|" + message);
        }

        public void Error(string message, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}