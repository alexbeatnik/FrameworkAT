using ATFramework.Base;
using ATFramework.Extentions;
using OpenQA.Selenium;

namespace ATesting.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(ParallelConfig paralelConfig) : base(paralelConfig)
        {
        }
        
        // [FindsBy(How = How.Id, Using = "loginLink")]
        // IWebElement lnkLogIn { get; set; }
        //
        // [FindsBy(How = How.LinkText, Using = "Log off")]
        // IWebElement lnkLogOff { get; set; }
        //
        // [FindsBy(How = How.XPath, Using = "//a[@title='Manage']")]
        // IWebElement lnkLoggedUser { get; set; }
        //
        // [FindsBy(How = How.LinkText, Using = "Employee List")]
        // IWebElement lnkEmployeeList { get; set; }

        public IWebElement lnkLogIn => _parallelConfig.Driver.FindElement(By.Id("loginLink"));
        public IWebElement lnkLogOff => _parallelConfig.Driver.FindElement(By.LinkText("Log off"));
        public IWebElement lnkLoggedUser => _parallelConfig.Driver.FindElement(By.XPath("//a[@title='Manage']"));
        public IWebElement lnkEmployeeList => _parallelConfig.Driver.FindElement(By.LinkText("Employee List"));

        public LoginPage ClickLoginLink()
        {
            lnkLogIn.Click();
            return new LoginPage(_parallelConfig);
        }


        public string GetLoogedInUser() => lnkLoggedUser.GetLinkText();

        public EmployeeListPage ClickEmployeeList()
        {
            lnkEmployeeList.Click();
            return new EmployeeListPage(_parallelConfig);
        }

        public HomePage CheckIfLoginExists()
        {
            lnkLogIn.AssertElementPresent();
            return this;
        }
        
        public LoginPage ClickLogOff()
        {
            lnkLogOff.Click();
            return new LoginPage(_parallelConfig);
        }

  
    }
}