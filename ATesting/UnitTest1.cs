using ATesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using ATFramework.Base;
using ATFramework.Helpers;
using ATFramework.Config;
using System;

namespace ATesting
{
    public class Tests : HookInitialize
    {
        [SetUp]
        public void Setup()
        {
        }

        // [Test]
        // public void Test1()
        // {
        //     string filename = Environment.CurrentDirectory.ToString() + "\\Data\\login.xls";
        //     ExelHelpers.PopulateCollection(filename);
        //     ConfigReader.SetFrameworksSettings();
        //     LogHelpers.CreateLogFile();
        //     OpenBrowser(BrowserType.Firefox);
        //     LogHelpers.Write("Open the browser!!!");
        //     DriverContext.Browser.GoToUrl(Settings.AUT);
        //     LogHelpers.Write("Navigated to the page");
        //
        //     CurrentPage = GetInstance<LoginPage>();
        //     CurrentPage.As<LoginPage>()
        //         .ClickLoginLink()
        //         .CheckIfLoginExists()
        //         .LogIn(ExelHelpers.ReadData(1, "UserName"), ExelHelpers.ReadData(1, "Password"))
        //         .ClickEmployeeList()
        //         .ClickButtonCreateNew();
        // }

        [Test]
        public void TableOperation()
        {
            string filename = Environment.CurrentDirectory.ToString() + "\\Data\\login.xls";
            ExelHelpers.PopulateCollection(filename);
        
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage.As<HomePage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().LogIn(ExelHelpers.ReadData(1, "UserName"), ExelHelpers.ReadData(1, "Password"));
            CurrentPage = GetInstance<LoginPage>();
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
        
        
            var table = CurrentPage.As<EmployeeListPage>().GetEmployeeList();
            HtmlTableHelper.ReadTable(table);
            HtmlTableHelper.PerformActionOnCell("5", "Name", "Ramesh", "Edit");
        }
    }
}