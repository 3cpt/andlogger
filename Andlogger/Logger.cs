using System;
using Andlogger.Strategies;

namespace Andlogger
{
    public class Logger : ILog
    {
        private IStrategy strategy;

        public Logger(Level level, string path, char separator = '|')
        {
            this.strategy = new FileLog(level, path, separator);
        }

        public Logger(Level level, string path)
        {
            this.strategy = new JsonLog(level, path);
        }

        public void Debug(string message)
        {
            this.strategy.Save(new Log(Level.Debug, message));
        }

        public void Debug(string message, Exception exception)
        {
            this.strategy.Save(new Log(Level.Debug, message, exception));
        }

        public void Info(string message)
        {
            this.strategy.Save(new Log(Level.Info, message));
        }

        public void Warning(string message)
        {
            this.strategy.Save(new Log(Level.Warning, message));
        }

        public void Error(string message)
        {
            this.strategy.Save(new Log(Level.Error, message));
        }

        public void Error(string message, Exception exception)
        {
            this.strategy.Save(new Log(Level.Error, message, exception));
        }
    }
}