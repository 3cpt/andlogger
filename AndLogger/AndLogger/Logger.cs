using AndLogger;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoBlogger.Controllers
{
    public static class Logger
    {
        private static Options _options;

        /// <summary>
        /// Write a Debug to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogDebug(string Message)
        {
            WriteLogFile(FormatedDate() + "|DEBUG|" + Message);
        }

        /// <summary>
        /// Write a Debug to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogDebug(string Method, string Message)
        {
            WriteLogFile(FormatedDate() + "|DEBUG|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogError(string Message)
        {
            WriteLogFile(FormatedDate() + "|ERROR|" + Message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogError(string Method, string Message)
        {
            WriteLogFile(FormatedDate() + "|ERROR|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// Write an Error to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        /// <param name="Exception">Exception generated in the catch</param>
        public static void LogError(string Method, string Message, Exception Exception)
        {
            WriteLogFile(FormatedDate() + "|DEBUG|METHOD:" + Method + "|" + Message + "|" + Exception.StackTrace);
        }

        /// <summary>
        /// Write an Info to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogInfo(string Message)
        {
            WriteLogFile(FormatedDate() + "|INFO|" + Message);
        }

        /// <summary>
        /// Write an Info to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogInfo(string Method, string Message)
        {
            WriteLogFile(FormatedDate() + "|INFO|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// Write a Warning to the Log file
        /// </summary>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogWarning(string Message)
        {
            WriteLogFile(FormatedDate() + "|WARNING|" + Message);
        }

        /// <summary>
        /// Write a Warning to the Log file
        /// </summary>
        /// <param name="Method">Method where the log is called</param>
        /// <param name="Message">Message that will be added to the Log</param>
        public static void LogWarning(string Method, string Message)
        {
            WriteLogFile(FormatedDate() + "|WARNING|METHOD:" + Method + "|" + Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadLogFile()
        {
            List<string> result = new List<string>();
            if (!File.Exists(_options.Path))
            {
                using (StreamReader sr = File.OpenText(_options.Path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        result.Add(s);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Return the current date in managed format
        /// </summary>
        /// <returns>Datet time now in <i>yyyy-MM-dd HH:mm:ss</i> format</returns>
        private static string FormatedDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private static void WriteLogFile(string newLine)
        {
            try
            {
                if (_options == null)
                {
                    // To verify another way to use this
                    _options = new Options().Load();
                }

                if (!File.Exists(_options.Path))
                {
                    using (StreamWriter sw = File.CreateText(_options.Path))
                    {
                        sw.WriteLine(newLine);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(_options.Path))
                    {
                        sw.WriteLine(newLine);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}