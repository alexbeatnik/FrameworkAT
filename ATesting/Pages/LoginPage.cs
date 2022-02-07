using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using ATFramework.Extentions;

namespace ATesting.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "UserName")]
        IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        IWebElement btnLogin { get; set; }


        public LoginPage LogIn(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
            return this;
        }

        public HomePage ClickLoginButton()
        {
            btnLogin.Click();
            return GetInstance<HomePage>();
        }

        public LoginPage CheckIfLoginExists()
        {
            txtUserName.AssertElementPresent();
            return this;
        }
    }
}