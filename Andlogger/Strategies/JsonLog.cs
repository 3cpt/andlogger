using System;

namespace Andlogger.Strategies
{
    internal class JsonLog : IStrategy
    {
        private string path;
        private Level level;
        private string fileName = "logger";
        private string extension = ".json";

        public JsonLog(Level level, string path)
        {
            this.level = level;
            this.path = path;
        }

        public void Save(Log log)
        {
            throw new NotImplementedException();
        }
    }
}