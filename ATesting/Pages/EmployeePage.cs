using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement txtSearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        public IWebElement buttonCreateNew { get; set; }

        public CreateEmployeePage ClickButtonCreateNew()
        {
            buttonCreateNew.Click();
            return new CreateEmployeePage();
        }
    }
}
