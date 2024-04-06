using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unoia.src
{
    internal static class Logger
    {
        private static DateTime time;
        public static string message;

        public static void setInfoMessage(string msg)
        {
            time = DateTime.Now;
            Console.WriteLine($"[{time}]Info: {msg}");
        }

        //TODO: red color warning
        public static void setWarningMessage(string msg)
        {
            time = DateTime.Now;
            Console.WriteLine($"[{time}]Warning: {msg}");
        }

    }
}
