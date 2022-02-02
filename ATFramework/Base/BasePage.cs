using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATFramework.Base
{
    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
