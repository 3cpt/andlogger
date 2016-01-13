using AndLogger;
using System;
using System.Collections.Generic;
using System.IO;

namespace AutoBlogger.Controllers
{
    public static class Logger
    {
        private static Options _options;

        public static void LogError(string Message)
        {
            WriteLogFile(FormatedDate() + "|ERROR|" + Message);
        }

        public static void LogError(string Method, string Message)
        {
            WriteLogFile(FormatedDate() + "|ERROR|METHOD:" + Method + "|" + Message);
        }

        public static void LogWarning(string Message)
        {
            WriteLogFile(FormatedDate() + "|WARNING|" + Message);
        }

        public static void LogWarning(string Method, string Message)
        {
            WriteLogFile(FormatedDate() + "|WARNING|METHOD:" + Method + "|" + Message);
        }

        public static void LogInfo(string Message)
        {
            WriteLogFile(FormatedDate() + "|INFO|" + Message);
        }

        public static void LogInfo(string Method, string Message)
        {
            WriteLogFile(FormatedDate() + "|INFO|METHOD:" + Method + "|" + Message);
        }

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
                    Options o = new Options();
                    _options = o.Load();
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
                throw;
            }
        }

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
    }
}