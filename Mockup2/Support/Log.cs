using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mockup2.Support
{
    public static class Log
    {
        private static List<string> runningLog = new List<string>();
        public static void WriteLine(string s)
        {
            string newS = DateTime.Now.ToString() + " : " + s;
            Console.WriteLine(newS);
            runningLog.Add( newS);
        }

        public static void WriteLine()
        {
            WriteLine("");
        }

        public static void WriteLine(object o)
        {
            WriteLine(o.ToString());
        }

        public static void WriteLine(string s, params object[] o)
        {
            WriteLine(string.Format(s,o));
        }

        public static void SaveLogToFile(string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName);
            foreach(string s in runningLog)
            {
                sw.WriteLine(s);
            }
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        public static void SaveLog()
        {
            SaveLogToFile("debuglog.txt");
        }
    }
}
