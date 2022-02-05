using ATesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using ATFramework.Base;
using ATFramework.Helpers;
using ATFramework.Config;
using System;

namespace ATesting
{
    public class Tests : Base
    {
        public void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Edge:
                    DriverContext.Driver = new EdgeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string filename = Environment.CurrentDirectory.ToString() + "\\Data\\login.xls";
            ExelHelpers.PopulateCollection(filename);
            ConfigReader.SetFrameworksSettings();
            LogHelpers.CreateLogFile();
            OpenBrowser(BrowserType.Firefox);
            LogHelpers.Write("Open the browser!!!");
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Navigated to the page");

            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>()
                .ClickLoginLink()
                .CheckIfLoginExists()
                .LogIn(ExelHelpers.ReadData(1, "UserName"), ExelHelpers.ReadData(1, "Password"))
                .ClickEmployeeList()
                .ClickButtonCreateNew();
        }
    }
}