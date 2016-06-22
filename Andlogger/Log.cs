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
        public static string Debug(string message)
        {
            return WriteLogFile("|DEBUG|" + message);
        }

        /// <summary>
        /// Write a Debug to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Debug(string message, string method)
        {
            return WriteLogFile("|DEBUG|METHOD:" + method + "|" + message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Error(string message)
        {
            return WriteLogFile("|ERROR|" + message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Error(string message, string method)
        {
            return WriteLogFile("|ERROR|METHOD:" + method + "|" + message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        /// <param name="Exception">Exception generated in the catch</param>
        public static string Error(string message, string method, Exception exception)
        {
            return WriteLogFile("|DEBUG|METHOD:" + method + "|" + message + "|" + exception.StackTrace);
        }

        /// <summary>
        /// Write an Info to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Info(string message)
        {
            return WriteLogFile("|INFO|" + message);
        }

        /// <summary>
        /// Write an Info to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Info(string message, string method)
        {
            return WriteLogFile("|INFO|METHOD:" + method + "|" + message);
        }

        /// <summary>
        /// Write a Warning to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Warning(string message)
        {
            return WriteLogFile("|WARNING|" + message);
        }

        /// <summary>
        /// Write a Warning to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static string Warning(string message, string method)
        {
            return WriteLogFile("|WARNING|METHOD:" + method + "|" + message);
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

        /// <summary>
        /// Return the current date in managed format
        /// </summary>
        /// <returns>Datet time now in <i>yyyy-MM-dd HH:mm:ss</i> format</returns>
        private static string FormatedDate()
        {
            return "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
        }
    }
}