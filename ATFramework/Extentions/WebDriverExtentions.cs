using OpenQA.Selenium;
using System;
using System.Diagnostics;

namespace ATFramework.Extentions
{
    public static class WebDriverExtentions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute = (arg) =>
            {
                try
                {
                    return condition(arg);
                }
                catch (Exception ex)
                {
                    return false;
                }
            };
            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }
    }
}