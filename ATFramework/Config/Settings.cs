using ATFramework.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ATFramework.Config
{
    public class Settings
    {
        public static string TestType { get; set; }
        public static string AUT { get; set; }
        public static string BuildName { get; set; }
        public static BrowserType BrowserType { get; set; }
        public static SqlConnection ApplicationConnection { get; set; }
        public static string AppConnectionString { get; set; }
        public static string IsLog { get; set; }
        public static string LogPath { get; set; }
    }
}