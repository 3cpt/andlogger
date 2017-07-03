namespace Andlogger.Strategies
{
    using System;
    using System.IO;
    using System.Text;

    internal class FileLog : IStrategy
    {
        private string fullpath;
        private Level level;
        private string fileName = "logger";

        // todo : implement an interface like ILogSettings where we can define file name, formate (ex. [date]), path, etc
        
        public FileLog(Level level, string path)
        {
            this.level = level;
            this.fullpath = path + fileName + ".txt";

            this.CreateLogFile();
        }

        public void Write(Log log)
        {
            if (log.Level >= this.level)
            {
                try
                {
                    string message = this.Render(log);

                    using (StreamWriter streamWriter = File.AppendText(fullpath))
                    {
                        streamWriter.WriteLine(message);
                        streamWriter.Flush();
                        streamWriter.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void CreateLogFile()
        {
            using (StreamWriter streamWriter = File.AppendText(this.fullpath))
            {
                streamWriter.Dispose();
            }
        }

        private string Render(Log log)
        {
            char separator = '|';

            StringBuilder sb = new StringBuilder();

            sb.Append(Helpers.FormatedDate(log.Timestamp)).Append(separator);
            sb.Append(log.Level.ToString().ToUpper()).Append(separator);
            sb.Append(log.Message);
            if (log.Exception != null)
            {
                sb.Append(separator);
                sb.Append(">>>TRACE>>>");
                sb.Append(log.Exception.Message);
                sb.Append(">>>");
                sb.Append(log.Exception.StackTrace);
            }

            return sb.ToString();
        }
    }
}