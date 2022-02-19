using ATFramework.Base;
using OpenQA.Selenium;


namespace ATesting.Pages
{
    public class EmployeeListPage : BasePage
    {
        public EmployeeListPage(ParallelConfig paralelConfig) : base(paralelConfig)
        {
        }
        // [FindsBy(How = How.Name, Using = "searchTerm")]
        // public IWebElement txtSearch { get; set; }
        //
        // [FindsBy(How = How.LinkText, Using = "Create New")]
        // public IWebElement buttonCreateNew { get; set; }
        //
        // [FindsBy(How = How.ClassName, Using = "table")]
        // public IWebElement tblEmployeeList { get; set; }

        public IWebElement txtSearch => _parallelConfig.Driver.FindElement(By.Id("searchTerm"));
        public IWebElement buttonCreateNew => _parallelConfig.Driver.FindElement(By.LinkText("Create New"));
        public IWebElement tblEmployeeList => _parallelConfig.Driver.FindElement(By.ClassName("table"));


        public CreateEmployeePage ClickButtonCreateNew()
        {
            buttonCreateNew.Click();
            return new CreateEmployeePage(_parallelConfig);
        }

        public IWebElement GetEmployeeList()
        {
            return tblEmployeeList;
        }
    }
}