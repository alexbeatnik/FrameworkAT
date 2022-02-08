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
        // public static void SetFrameworksSettings()
        // {
        //     XPathItem aut;
        //     XPathItem testtype;
        //     XPathItem buildname;
        //     XPathItem islog;
        //     XPathItem isreport;
        //     XPathItem logpath;
        //     XPathItem appConnection;
        //
        //     string strFileName = Environment.CurrentDirectory.ToString() + "\\config\\GlobalConfig.xml";
        //     FileStream stream = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
        //     XPathDocument document = new XPathDocument(stream);
        //     XPathNavigator navigator = document.CreateNavigator();
        //     
        //     aut = navigator.SelectSingleNode("FrameworkAT/RunSettings/AUT");
        //     testtype = navigator.SelectSingleNode("FrameworkAT/RunSettings/TestType");
        //     buildname = navigator.SelectSingleNode("FrameworkAT/RunSettings/BuildName");
        //     islog = navigator.SelectSingleNode("FrameworkAT/RunSettings/IsLog");
        //     isreport = navigator.SelectSingleNode("FrameworkAT/RunSettings/IsReport");
        //     logpath = navigator.SelectSingleNode("FrameworkAT/RunSettings/LogPath");
        //     appConnection = navigator.SelectSingleNode("FrameworkAT/RunSettings/ApplicationDb");
        //     
        //     Settings.AUT = aut.ToString();
        //     Settings.IsLog = islog.ToString();
        //     Settings.TestType = testtype.ToString();
        //     Settings.IsLog = islog.ToString();
        //     Settings.LogPath = logpath.ToString();
        //     Settings.BuildName = buildname.ToString();
        //     Settings.AppConnectionString = appConnection.Value.ToString();
        // }
        
        public static void SetFrameworksSettings(string settingType)
        {


            Settings.AUT = FrameworkAtConfiguration.FSettings.TestSettings[settingType].AUT;
            Settings.IsLog = FrameworkAtConfiguration.FSettings.TestSettings[settingType].Islog;
            Settings.TestType = FrameworkAtConfiguration.FSettings.TestSettings[settingType].TestType;
            Settings.IsLog = FrameworkAtConfiguration.FSettings.TestSettings[settingType].Islog;
            Settings.LogPath = FrameworkAtConfiguration.FSettings.TestSettings[settingType].LogPath;
            // Settings.BuildName = FrameworkAtConfiguration.FSettings.TestSettings["staging"];
            Settings.AppConnectionString = FrameworkAtConfiguration.FSettings.TestSettings[settingType].AppDb;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), FrameworkAtConfiguration.FSettings.TestSettings[settingType].Browser);
        }
    }
}