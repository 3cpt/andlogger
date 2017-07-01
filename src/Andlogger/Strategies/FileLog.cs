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

        public FileLog(Level level, string path)
        {
            this.level = level;
            this.fullpath = path + fileName + ".txt";

            this.CreateLogFile();
        }

        public void Write(Log log)
        {
            if (log.Level <= this.level)
            {
                try
                {
                    this.CreateLogFile();

                    string message = this.Render(log);

                    using (StreamWriter streamWriter = File.AppendText(fullpath))
                    {
                        streamWriter.WriteLine(message);
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
            FileInfo fileInfo = new FileInfo(fullpath);
            if (fileInfo.Exists)
            {
                if (fileInfo.IsReadOnly)
                {
                    throw new FileLoadException("File is Read Only", fullpath);
                }

                if (fileInfo.Length > 2048)
                {
                    File.Move(fullpath, fullpath + Guid.NewGuid().ToString());
                    File.Create(fullpath);
                }
            }
            else
            {
                var stream = File.Create(fullpath);
                stream.Flush();
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
                sb.Append("\n>>>TRACE>>>");
                sb.Append(log.Exception.Message);
                sb.Append(">>>");
                sb.Append(log.Exception.StackTrace);
            }

            return sb.ToString();
        }
    }
}