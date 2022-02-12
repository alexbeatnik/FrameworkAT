using ATFramework.Base;
using ATFramework.Extentions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATesting.Pages
{
    public class EmployeeListPage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement txtSearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        public IWebElement buttonCreateNew { get; set; }

        [FindsBy(How = How.ClassName, Using = "table")]
        public IWebElement tblEmployeeList { get; set; }


        public CreateEmployeePage ClickButtonCreateNew()
        {
            buttonCreateNew.Click();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            return tblEmployeeList;
        }
    }
}