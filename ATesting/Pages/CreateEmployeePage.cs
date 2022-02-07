using ATFramework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATesting.Pages
{
    public class CreateEmployeePage : BasePage
    {
        [FindsBy(How = How.Id, Using = "Name")]
        public IWebElement txtName { get; set; }

        [FindsBy(How = How.Id, Using = "Salary")]
        public IWebElement txtSalary { get; set; }

        [FindsBy(How = How.Id, Using = "DurationWorked")]
        public IWebElement txtDurationWorked { get; set; }

        [FindsBy(How = How.Id, Using = "Grade")]
        public IWebElement txtGrade { get; set; }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Create']")]
        public IWebElement btnCeateEmployee { get; set; }

        public EmployeeListPage ClickButtonCreate()
        {
            btnCeateEmployee.Click();
            return GetInstance<EmployeeListPage>();
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