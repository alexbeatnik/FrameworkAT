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
    public class EmployeePage : BasePage
    {
        public EmployeePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "searchTerm")]
        public IWebElement lnkLogin { get; set; }
    }
}
