using System;

namespace Andlogger.Strategies
{
    public class JsonLog : IStrategy
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

        public void Save(Level level, string log)
        {
            throw new NotImplementedException();
        }
    }
}