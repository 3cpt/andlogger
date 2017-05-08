using NUnit.Framework;
using Andlogger;
using System;

namespace AndLogger.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        private ILog log;

        [SetUp]
        public void Init()
        {
            this.log = new Logger(Level.Warning, "c:\\");
        }

        static object[] Message =
        {
            new object[] { null, "" },
            new object[] { "", "" },
            new object[] { "message", "message" }
        };

        static object[] MessageMethod =
        {
            new object[] { null, null, "" },
            new object[] { "", "", "" },
            new object[] { "method", "message", "message" }
        };

        //[Test, TestCaseSource("Message")]
        //[Category("Debug")]
        //public void LogDebug_Message(string message, string expected)
        //{
        //    string act = this.log.Debug(message);
        //    string exp = "|DEBUG|" + expected;
        //    Assert.AreEqual(exp, act);
        //}

        //[Test, TestCaseSource("MessageMethod")]
        //[Category("Debug")]
        //public void LogDebug_MethodMessage(string method, string message, string expected)
        //{
        //    string actual = this.log.Debug(message, method);
        //    string exp = "|DEBUG|METHOD:" + method + "|" + message;
        //    Assert.AreEqual(exp, actual);
        //}

        //[Test, TestCaseSource("Message")]
        //[Category("Info")]
        //public void LogInfo_Message(string message, string expected)
        //{
        //    string act = this.log.Info(message);
        //    string exp = "|INFO|" + expected;
        //    Assert.AreEqual(exp, act);
        //}

        //[Test, TestCaseSource("MessageMethod")]
        //[Category("Info")]
        //public void LogInfo_MethodMessage(string method, string message, string expected)
        //{
        //    string actual = this.log.Info(message, method);
        //    string exp = "|INFO|METHOD:" + method + "|" + message;
        //    Assert.AreEqual(exp, actual);
        //}

        //[Test, TestCaseSource("Message")]
        //[Category("Warning")]
        //public void LogWarning_Message(string message, string expected)
        //{
        //    string act = this.log.Warning(message);
        //    string exp = "|WARNING|" + expected;
        //    Assert.AreEqual(exp, act);
        //}

        //[Test, TestCaseSource("MessageMethod")]
        //[Category("Warning")]
        //public void LogWarning_MethodMessage(string method, string message, string expected)
        //{
        //    string actual = this.log.Warning(message, method);
        //    string exp = "|WARNING|METHOD:" + method + "|" + message;
        //    Assert.AreEqual(exp, actual);
        //}

        //[Test, TestCaseSource("Message")]
        //[Category("Error")]
        //public void LogError_Message(string message, string expected)
        //{
        //    string act = this.log.Error(message);
        //    string exp = "|ERROR|" + expected;
        //    Assert.AreEqual(exp, act);
        //}

        //[Test, TestCaseSource("MessageMethod")]
        //[Category("Error")]
        //public void LogError_MethodMessage(string method, string message, string expected)
        //{
        //    string actual = this.log.Error(message, method);
        //    string exp = "|ERROR|METHOD:" + method + "|" + message;
        //    Assert.AreEqual(exp, actual);
        //}

        //[TestCase("", "", "")]
        //[Category("Error")]
        //public void LogError_MethodMessageException(string method, string message, string expected)
        //{
        //    string actual = this.log.Error(message, method, new Exception());
        //    string exp = "|ERROR|METHOD:" + method + "|" + message + "|";
        //    Assert.AreEqual(exp, actual);
        //}
    }
}