using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andlogger
{
    public class Log
    {
        public Level Level { get; set; }

        public string Message { get; set; }

        public string  Method { get; set; }

        public Exception Exception { get; set; }

        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
