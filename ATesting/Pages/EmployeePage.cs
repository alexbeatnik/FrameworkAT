using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class EmployeePage : BasePage
    {
        public EmployeePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement lnkLogin { get; set; }
    }
}
