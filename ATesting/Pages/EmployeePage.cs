using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement lnkLogin { get; set; }
    }
}
