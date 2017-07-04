using System;
using Andlogger;

namespace AcceptanceTests
{
    public class Tests
    {
        public static void Main (string[] args)
        {
            ILog log = new Logger(Level.Debug, "");

            log.Debug("debug");
            log.Debug("debug", new Exception("exception.debug"));

            log.Info("info");
            
            log.Warning("Warning");

            log.Error("Error");
            log.Error("Error", new Exception("exception.Error"));

            log.Debug("debug");
        }
    }
}
