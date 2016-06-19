using NUnit.Framework;
using andcorreia;

namespace AndLogger.Tests
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        public void LogDebug1()
        {
            string actual = Andlogger.LogDebug(null);
            string expected = "|DEBUG|";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug2()
        {
            string actual = Andlogger.LogDebug("debug_message");
            string expected = "|DEBUG|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug3()
        {
            string actual = Andlogger.LogDebug(null, "debug_message");
            string expected = "|DEBUG|METHOD:|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug4()
        {
            string actual = Andlogger.LogDebug(string.Empty, "debug_message");
            string expected = "|DEBUG|METHOD:|debug_message";
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LogDebug5()
        {
            string actual = Andlogger.LogDebug("method x", "debug_message");
            string expected = "|DEBUG|METHOD:method x|debug_message";
            Assert.AreEqual(expected, actual);
        }
    }
}
