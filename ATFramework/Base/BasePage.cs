using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATFramework.Base
{
    public abstract class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}
