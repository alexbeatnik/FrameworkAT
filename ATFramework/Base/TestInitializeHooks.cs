using System;
using ATFramework.Config;
using ATFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace ATFramework.Base
{
    public class TestInitializeHooks : Steps
    {
        private readonly ParallelConfig _parallelConfig;

        public TestInitializeHooks(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void InitializeSettings()
        {
            ConfigReader.SetFrameworksSettings();
            // LogHelpers.CreateLogFile();
            OpenBrowser(Settings.BrowserType);
            // LogHelpers.Write("Initialized framework");
        }

        // private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        // {
        //     switch (browserType)
        //     {
        //         case BrowserType.Firefox:
        //             var firefoxCaps = new FirefoxOptions();
        //             _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://10.14.225.109:4444"), firefoxCaps);
        //             break;
        //         case BrowserType.Chrome:
        //             var chromeCaps = new ChromeOptions();
        //             _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://10.14.225.109:4444"), chromeCaps);
        //             break;
        //         case BrowserType.Edge:
        //             var edgeCaps = new ChromeOptions();
        //             _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://10.14.225.109:4444"), edgeCaps);
        //             break;
        //     }
        // }
        //
        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    var firefoxCaps = new FirefoxOptions();
                    _parallelConfig.Driver =new FirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    var chromeCaps = new ChromeOptions();
                    _parallelConfig.Driver = new ChromeDriver();
                    break;
                case BrowserType.Edge:
                    var edgeCaps = new ChromeOptions();
                    _parallelConfig.Driver = new EdgeDriver();
                    break;
            }
        }

        public virtual void NavigateSite()
        {
           // DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Navigated to the page");
        }
    }
}