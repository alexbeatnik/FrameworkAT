using ATFramework.Base;
using OpenQA.Selenium;
using ATFramework.Extentions;

namespace ATesting.Pages
{
    public class LoginPage : BasePage
    {
        
        public LoginPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }
        // [FindsBy(How = How.Id, Using = "UserName")]
        // IWebElement txtUserName { get; set; }
        //
        // [FindsBy(How = How.Id, Using = "Password")]
        // IWebElement txtPassword { get; set; }
        //
        // [FindsBy(How = How.CssSelector, Using = "input.btn")]
        // IWebElement btnLogin { get; set; }

        
        public IWebElement txtUserName => _parallelConfig.Driver.FindElement(By.Id("UserName"));
        public IWebElement txtPassword => _parallelConfig.Driver.FindElement(By.Id("Password"));
        public IWebElement btnLogin => _parallelConfig.Driver.FindElement(By.CssSelector("input.btn"));


        public LoginPage LogIn(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
            return this;
        }

        public HomePage ClickLoginButton()
        {
            btnLogin.Click();
            return new HomePage(_parallelConfig);
        }

        public LoginPage CheckIfLoginExists()
        {
            txtUserName.AssertElementPresent();
            return new LoginPage(_parallelConfig);
        }


    }
}