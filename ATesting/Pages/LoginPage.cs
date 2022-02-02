using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement btnLogin { get; set; }
    }
}
