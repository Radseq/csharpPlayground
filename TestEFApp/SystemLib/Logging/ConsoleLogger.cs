using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemLib.Logging
{
    public class ConsoleLogger : ILog
    {
        private bool IsObjectString(object msg)
        {
            return msg.GetType() == typeof(string);
        }
        public void DEBUG(object msg)
        {
            if (IsObjectString(msg))
                Console.WriteLine($"DEBUG: {msg}");
        }

        public void ERROR(object msg)
        {
            if (IsObjectString(msg))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"ERROR: {msg}");
                Console.ResetColor();
            }
        }

        public void FATAL(Exception ex, object msg, [CallerMemberName] string callingMethod = "", [CallerFilePath] string callingFilePath = "", [CallerLineNumber] int callingFileLineNumber = 0)
        {
            if (IsObjectString(msg))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FATAL: {msg}," + "\n" +
                    $"Exception mesage: {ex.Message}," + "\n" +
                    $"Member Name {callingMethod}," + "\n" +
                    $"Line Number {callingFileLineNumber}," + "\n" +
                    $"File Patch {callingFilePath}");

                Console.ResetColor();
            }
        }

        public void INFO(object msg)
        {
            if (IsObjectString(msg))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"INFO: {msg}");
                Console.ResetColor();
            }
        }

        public void TRACE(object msg, [CallerMemberName] string callingMethod = "", [CallerFilePath] string callingFilePath = "", [CallerLineNumber] int callingFileLineNumber = 0)
        {
            if (IsObjectString(msg))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"TRACE: {msg}," + "\n" +
                  $"Member Name {callingMethod}," + "\n" +
                  $"Line Number {callingFileLineNumber}," + "\n" +
                  $"File Patch {callingFilePath}");
                Console.ResetColor();
            }
        }

        public void WARN(object msg)
        {
            if (IsObjectString(msg))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARN: {msg}");
                Console.ResetColor();
            }
        }
    }
}
