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
            string actual = Log.LogDebug(null);
            string expected = "|DEBUG|";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug2()
        {
            string actual = Log.LogDebug("debug_message");
            string expected = "|DEBUG|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug3()
        {
            string actual = Log.LogDebug(null, "debug_message");
            string expected = "|DEBUG|METHOD:|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug4()
        {
            string actual = Log.LogDebug(string.Empty, "debug_message");
            string expected = "|DEBUG|METHOD:|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug5()
        {
            string actual = Log.LogDebug("method x", "debug_message");
            string expected = "|DEBUG|METHOD:method x|debug_message";
            Assert.AreEqual(expected, actual);
        }
    }
}
