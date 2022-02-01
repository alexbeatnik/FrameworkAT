using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

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
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(url);
            LogIn();
            Assert.Pass();
        }

        public void LogIn()
        {
            _driver.FindElement(By.LinkText("Login")).Click();
            _driver.FindElement(By.Id("UserName")).SendKeys("admin");
            _driver.FindElement(By.Id("Password")).SendKeys("password");
            _driver.FindElement(By.CssSelector("input.btn")).Submit();

        }
    }
}