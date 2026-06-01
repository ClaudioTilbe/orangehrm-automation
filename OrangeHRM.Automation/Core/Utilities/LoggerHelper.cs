using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Core.Utilities
{
    public static class LoggerHelper
    {
        public static void Info(string message)
        {
            Console.WriteLine(
                $"[INFO] [{DateTime.Now:HH:mm:ss}] {message}");
        }

        public static void Error(string message)
        {
            Console.WriteLine(
                $"[ERROR] [{DateTime.Now:HH:mm:ss}] {message}");
        }

        public static void Warning(string message)
        {
            Console.WriteLine(
                $"[WARNING] [{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
