using ATFramework.Config;
using ATFramework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ATFramework.Base
{
    public abstract class TestInitializeHooks : Base
    {
        public readonly BrowserType Browser;

        public TestInitializeHooks(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeSettings()
        {
            ConfigReader.SetFrameworksSettings("stating");

            LogHelpers.CreateLogFile();

            OpenBrowser(Browser);
            LogHelpers.Write("Open the browser!!!");
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
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

        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write("Navigated to the page");
        }
    }
}