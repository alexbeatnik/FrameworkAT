using ATesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using ATFramework.Base;
using ATFramework.Helpers;
using ATFramework.Config;

namespace ATesting
{
    public class Tests : Base
    {
        string url = ConfigReader.InitializeTest();
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
            LogHelpers.CreateLogFile();
            OpenBrowser(BrowserType.Firefox);
            LogHelpers.Write("Open the browser!!!");
            DriverContext.Browser.GoToUrl(url);
            LogHelpers.Write("Navigated to the page");

            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<LoginPage>()
                .ClickLoginLink()
                .LogIn("admin", "password")
                .ClickEmployeeList()
                .ClickButtonCreateNew();
        }
    }
}