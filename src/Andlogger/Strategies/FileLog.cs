namespace Andlogger.Strategies
{
    using System;
    using System.IO;
    using System.Text;

    internal class FileLog : IStrategy
    {
        private string path;
        private Level level;
        private string fileName = "logger";
        private string extension = ".txt";
        private char separator = '|';

        public FileLog(Level level, string path, char separator)
        {
            this.level = level;
            this.path = path;
            this.separator = separator;
        }

        public void Save(Log log)
        {
            if (log.Level <= this.level)
            {
                try
                {
                    this.fileName = this.fileName + this.extension;

                    if (File.Exists(fileName))
                    {
                        FileInfo fileInfo = new FileInfo(fileName);
                        if (fileInfo.Length > 2048)
                        {
                            File.Move(fileName, fileName + Guid.NewGuid().ToString());
                            using (StreamWriter streamWriter = File.CreateText(fileName))
                            {
                                streamWriter.WriteLine(log);
                            }
                        }
                        else
                        {
                            using (StreamWriter streamWriter = File.AppendText(fileName))
                            {
                                streamWriter.WriteLine(log);
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter streamWriter = File.CreateText(fileName))
                        {
                            streamWriter.WriteLine(log);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private string Render(Log log)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Helpers.FormatedDate(log.Timestamp)).Append(separator);
            sb.Append(log.Level.ToString().ToUpper()).Append(separator);
            sb.Append(log.Message).Append(separator);
            if (log.Exception != null)
            {
                sb.Append("\n>>>TRACE>>>");
                sb.Append(log.Exception.Message);
                sb.Append(">>>");
                sb.Append(log.Exception.StackTrace).Append(separator);
            }

            return sb.ToString();
        }
    }
}