using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkExtractor.Adb
{
    public class AdbException : Exception
    {
        public AdbException() { }
        public AdbException(string message) : base(message) { }
        public AdbException(string message, Exception inner) : base(message, inner) { }
    }
}
