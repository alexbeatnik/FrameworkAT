using ATFramework.Base;
using OpenQA.Selenium;

namespace ATesting.Pages
{
    public class CreateEmployeePage : BasePage
    {
        
        public CreateEmployeePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }
        
        IWebElement txtName => _parallelConfig.Driver.FindElement(By.Id("Name"));
        IWebElement txtSalary => _parallelConfig.Driver.FindElement(By.Id("Salary"));
        IWebElement txtDurationWorked => _parallelConfig.Driver.FindElement(By.Id("DurationWorked"));
        IWebElement txtGrade => _parallelConfig.Driver.FindElement(By.Id("Grade"));
        IWebElement txtEmail => _parallelConfig.Driver.FindElement(By.Id("Email"));
        IWebElement btnCeateEmployee => _parallelConfig.Driver.FindElement(By.Name("Grade"));
        // [FindsBy(How = How.Id, Using = "Name")]
        // public IWebElement txtName { get; set; }
        //
        // [FindsBy(How = How.Id, Using = "Salary")]
        // public IWebElement txtSalary { get; set; }
        //
        // [FindsBy(How = How.Id, Using = "DurationWorked")]
        // public IWebElement txtDurationWorked { get; set; }
        //
        // [FindsBy(How = How.Id, Using = "Grade")]
        // public IWebElement txtGrade { get; set; }
        //
        // [FindsBy(How = How.Id, Using = "Email")]
        // public IWebElement txtEmail { get; set; }
        //
        // [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        // public IWebElement btnCeateEmployee { get; set; }


        public EmployeeListPage ClickButtonCreate()
        {
            btnCeateEmployee.Click();
            return new EmployeeListPage(_parallelConfig);
        }

        public void CreateEmployee(string name, string salary, string durationworked, string grade, string email)
        {
            txtName.SendKeys(name);
            txtSalary.SendKeys(salary);
            txtDurationWorked.SendKeys(durationworked);
            txtGrade.SendKeys(grade);
            txtEmail.SendKeys(email);
        }


    }
}