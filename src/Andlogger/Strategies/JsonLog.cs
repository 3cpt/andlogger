namespace Andlogger.Strategies
{
    using System;
    using System.IO;

    internal class JsonLog : IStrategy
    {
        private string path;
        private Level level;
        private string fileName = "logger";

        public JsonLog(Level level, string path)
        {
            this.level = level;
            this.path = path;
            throw new NotImplementedException();
        }

        public void Save(Log log)
        {
            var oooo = fileName + ".json";

            throw new NotImplementedException();
        }
    }
}