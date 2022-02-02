using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "loginLink")]
        public IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        public IWebElement lnkEmployeeList { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement btnLogin { get; set; }

        public LoginPage LogIn(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Submit();
            return this;
        }

        public LoginPage ClickLoginLink()
        {
            lnkLogin.Click();
            return this;
        }

        public EmployeePage ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return new EmployeePage();
        }
    }
}
