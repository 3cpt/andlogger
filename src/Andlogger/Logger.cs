namespace Andlogger
{
    using System;
    using Andlogger.Strategies;

    public class Logger : ILog
    {
        private IStrategy strategy;

        /// <summary>
        /// Instantiate a log based in a Text file (.txt)
        /// </summary>
        /// <param name="level">Minimun level that the log will write</param>
        /// <param name="path">Full or Partial path to the file location</param>
        /// <param name="separator">Character that will be used to split the the string. By default '|'</param>
        public Logger(Level level, string path)
        {
            this.strategy = new FileLog(level, path);
        }
        
        public void Debug(string message)
        {
            this.strategy.Write(new Log(Level.Debug, message));
        }

        public void Debug(string message, Exception exception)
        {
            this.strategy.Write(new Log(Level.Debug, message, exception));
        }

        public void Info(string message)
        {
            this.strategy.Write(new Log(Level.Info, message));
        }

        public void Warning(string message)
        {
            this.strategy.Write(new Log(Level.Warning, message));
        }

        public void Error(string message)
        {
            this.strategy.Write(new Log(Level.Error, message));
        }

        public void Error(string message, Exception exception)
        {
            this.strategy.Write(new Log(Level.Error, message, exception));
        }
    }
}