
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemLib
{
    public interface ILog
    {
        void DEBUG(object msg);
        void INFO(object msg);
        void WARN(object msg);
        void ERROR(object msg);
        void FATAL(Exception ex, object msg, [CallerMemberName] string callingMethod = "",
        [CallerFilePath] string callingFilePath = "",
        [CallerLineNumber] int callingFileLineNumber = 0);
        void TRACE(object msg, [CallerMemberName] string callingMethod = "",
        [CallerFilePath] string callingFilePath = "",
        [CallerLineNumber] int callingFileLineNumber = 0);
    }
}
