using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared
{
    public class Logging
    {
        public static void CriticalLog(string text)
        {
            if (!Directory.Exists("Log")) Directory.CreateDirectory("Log");
            var filename = string.Format("CriticalError({0:yyyyMMdd}).txt", DateTime.Now);

            // get call stack
            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1).GetMethod();
            var output = string.Format("{0}{1}({2})\t[{3:yyyy-MM-dd HH:mm:ss.sss}] {4}", callingMethod.DeclaringType.Name, callingMethod.Name, stackTrace.GetFrame(1).GetILOffset(), DateTime.Now, text);
            using (var fs = new FileStream(Path.Combine("Log", filename), FileMode.OpenOrCreate))
            {
                fs.Seek(0, SeekOrigin.End);
                using (var sw = new StreamWriter(fs))
                    sw.WriteLine(output);
            }
        }
    }
}
