using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using ATFramework.Base;
using ATFramework.ConfigElement;

namespace ATFramework.Config
{
    public class ConfigReader
    {
        public static void SetFrameworksSettings(string settingType = "stating")
        {
            Settings.AUT = FrameworkAtConfiguration.FSettings.TestSettings[settingType].AUT;
            Settings.IsLog = FrameworkAtConfiguration.FSettings.TestSettings[settingType].Islog;
            Settings.TestType = FrameworkAtConfiguration.FSettings.TestSettings[settingType].TestType;
            Settings.IsLog = FrameworkAtConfiguration.FSettings.TestSettings[settingType].Islog;
            Settings.LogPath = FrameworkAtConfiguration.FSettings.TestSettings[settingType].LogPath;
            // Settings.BuildName = FrameworkAtConfiguration.FSettings.TestSettings["staging"];
            Settings.AppConnectionString = FrameworkAtConfiguration.FSettings.TestSettings[settingType].AppDb;
            Settings.BrowserType = (BrowserType) Enum.Parse(typeof(BrowserType),
                FrameworkAtConfiguration.FSettings.TestSettings[settingType].Browser);
        }
    }
}