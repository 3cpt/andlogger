using System;

namespace Andlogger
{
    public static class Helpers
    {
        /// <summary>
        /// Return the current date in managed format
        /// </summary>
        /// <returns>Datet time now in <i>yyyy-MM-dd HH:mm:ss</i> format</returns>
        internal static string FormatedDate(DateTime date)
        {
            return "[" + date.ToString("yyyy-MM-dd HH:mm:ss") + "]";
        }
    }
}