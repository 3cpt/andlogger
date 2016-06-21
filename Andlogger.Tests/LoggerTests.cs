using NUnit.Framework;
using Andlogger;

namespace AndLogger.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void LogDebug1()
        {
            string actual = Log.Debug(null);
            string expected = "|DEBUG|";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug2()
        {
            string actual = Log.Debug("debug_message");
            string expected = "|DEBUG|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug3()
        {
            string actual = Log.Debug(null, "debug_message");
            string expected = "|DEBUG|METHOD:|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug4()
        {
            string actual = Log.Debug(string.Empty, "debug_message");
            string expected = "|DEBUG|METHOD:|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug5()
        {
            string actual = Log.Debug("method x", "debug_message");
            string expected = "|DEBUG|METHOD:method x|debug_message";
            Assert.AreEqual(expected, actual);
        }
    }
}
