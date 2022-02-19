using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace ATFramework.Base;

public class ParallelConfig
{
    public IWebDriver Driver { get; set; }
    public BasePage CurrentPage { get; set; }
}