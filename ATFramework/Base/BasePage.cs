using SeleniumExtras.PageObjects;

namespace ATFramework.Base
{
    public abstract class BasePage : Base
    {
        public BasePage()
        {
            PageFactory.InitElements(DriverContext.Driver, this);
        }
    }
}