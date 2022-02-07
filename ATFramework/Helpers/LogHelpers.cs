using ATFramework.Config;
using System;
using System.IO;

namespace ATFramework.Helpers
{
    public class LogHelpers
    {
        private static string _logFileName = String.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        public static void CreateLogFile()
        {
            string dir = Settings.LogPath;
            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
        }

        public static void Write(string logMassage)
        {
            _streamw.Write($"{DateTime.Now.ToLongTimeString()}, {DateTime.Now.ToLongDateString()}");
            _streamw.Write($" {logMassage}\n");
            _streamw.Flush();
        }
    }
}