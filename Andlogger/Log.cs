using System;
using System.IO;

namespace Andlogger
{
    public static class Log
    {
        private static string ConstFileName = "logger.txt";

        /// <summary>
        /// Write a Debug to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Debug(string Message)
        {
            return WriteLogFile("|DEBUG|" + Message);
        }

        /// <summary>
        /// Write a Debug to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Debug(string Method, string Message)
        {
            return WriteLogFile("|DEBUG|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Error(string Message)
        {
            return WriteLogFile("|ERROR|" + Message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Error(string Method, string Message)
        {
            return WriteLogFile("|ERROR|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        /// <param name="Exception">Exception generated in the catch</param>
        public static string Error(string Method, string Message, Exception Exception)
        {
            return WriteLogFile("|DEBUG|METHOD:" + Method + "|" + Message + "|" + Exception.StackTrace);
        }

        /// <summary>
        /// Write an Info to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Info(string Message)
        {
            return WriteLogFile("|INFO|" + Message);
        }

        /// <summary>
        /// Write an Info to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Info(string Method, string Message)
        {
            return WriteLogFile("|INFO|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// Write a Warning to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Warning(string Message)
        {
            return WriteLogFile("|WARNING|" + Message);
        }

        /// <summary>
        /// Write a Warning to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Warning(string Method, string Message)
        {
            return WriteLogFile("|WARNING|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// Return the current date in managed format
        /// </summary>
        /// <returns>Datet time now in <i>yyyy-MM-dd HH:mm:ss</i> format</returns>
        private static string FormatedDate()
        {
            return "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
        }

        private static string WriteLogFile(string newLog)
        {
            try
            {
                string log = FormatedDate() + newLog;
                if (File.Exists(ConstFileName))
                {
                    FileInfo fileInfo = new FileInfo(ConstFileName);
                    if (fileInfo.Length > 2048)
                    {
                        File.Move(ConstFileName, ConstFileName + Guid.NewGuid().ToString());
                        using (StreamWriter streamWriter = File.CreateText(ConstFileName))
                        {
                            streamWriter.WriteLine(log);
                        }
                    }
                    else
                    {
                        using (StreamWriter streamWriter = File.AppendText(ConstFileName))
                        {
                            streamWriter.WriteLine(log);
                        }
                    }
                }
                else
                {
                    using (StreamWriter streamWriter = File.CreateText(ConstFileName))
                    {
                        streamWriter.WriteLine(log);
                    }
                }
            }
            catch (Exception ex)
            {
                newLog = string.Empty;
                throw ex;
            }

            return newLog;
        }
    }
}