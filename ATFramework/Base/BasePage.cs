using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATFramework.Base
{
    public abstract class BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
