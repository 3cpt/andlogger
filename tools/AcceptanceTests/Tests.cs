using System;
using Andlogger;

namespace AcceptanceTests
{
    public class Tests
    {
        public static void Main (string[] args)
        {
            ILog log = new Logger(Level.Warning, "");

            log.Debug("debug");
        }
    }
}
