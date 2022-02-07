using ATFramework.Base;
using ATFramework.Extentions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "loginLink")]
        IWebElement lnkLogIn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Log off")]
        IWebElement lnkLogOff { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Manage]'")]
        IWebElement lnkLoggedUser { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement lnkEmployeeList { get; set; }



        public LoginPage ClickLoginLink()
        {
            lnkLogIn.Click();
            return GetInstance<LoginPage>();
        }

      
        internal string GetLoogedInUser()
        {
            return lnkLoggedUser.GetLinkText();
        }

        public EmployeeListPage ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }

        public HomePage CheckIfLoginExists()
        {
            lnkLogIn.AssertElementPresent();
            return this;
        }
    }
}
