using System;
using System.IO;

namespace Andlogger
{
    public class Log : ILog
    {
        private IStrategy strategy;

        public Log(Level level, string path)
        {
            this.strategy = new FileLog(level, path);
        }
        
        public void Debug(string message)
        {
            this.strategy.Save(Level.Debug, FormatedDate() + "|DEBUG|" + message);
        }
        
        
        /// <summary>
        /// Return the current date in managed format
        /// </summary>
        /// <returns>Datet time now in <i>yyyy-MM-dd HH:mm:ss</i> format</returns>
        private static string FormatedDate()
        {
            return "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
        }


        public void Debug(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        void ILog.Info(string message)
        {
            throw new NotImplementedException();
        }

        void ILog.Warning(string message)
        {
            throw new NotImplementedException();
        }

        void ILog.Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}