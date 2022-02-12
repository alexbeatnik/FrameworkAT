using ATFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATFramework.Extentions
{
    public static class WebElementExentions
    {
        public static string GetSelectedDropDown(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions.First().ToString();
        }

        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);
            return ddl.AllSelectedOptions;
        }

        public static void Hover(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }

        public static void SelectDropDownList(this IWebElement element, string value)
        {
            SelectElement ddl = new SelectElement(element);
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
            {
                throw new Exception(string.Format("Element Not Present Exception"));
            }
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}