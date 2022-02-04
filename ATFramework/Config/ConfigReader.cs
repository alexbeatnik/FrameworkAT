using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ATFramework.Config
{
    public class ConfigReader
    {
        public static string InitializeTest()
        {
            ConfigurationManager.AppSettings["AUT"].ToString();
        }
    }
}
