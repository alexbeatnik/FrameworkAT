using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "loginLink")]
        IWebElement lnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement lnkEmployeeList { get; set; }

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
