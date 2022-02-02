using ATesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using ATFramework.Base;

namespace ATesting
{
    public class Tests
    {
        private IWebDriver _driver;
        string url = "http://eaapp.somee.com/";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DriverContext.Driver = new FirefoxDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);
            LogIn();
            Assert.Pass();
        }

        public void LogIn()
        {
            LoginPage page = new LoginPage();
            page.lnkLogin.Click();
            page.txtUserName.SendKeys("admin");
            page.txtPassword.SendKeys("password");
            page.btnLogin.Submit();

        }
    }
}