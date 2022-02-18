using ATesting.Pages;
using ATFramework.Base;
using ATFramework.Config;
using ATFramework.Helpers;
using TechTalk.SpecFlow;

namespace ATesting.Steps;

[Binding]
public class ExtendedSteps : BaseStep
{
    
    public virtual void NavigateSite()
    {
        _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
        _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
        LogHelpers.Write("Navigated to the page");
    }
    
    [Given(@"I check app opened")]
    public void GivenICheckAppOpened()
    {
        _parallelConfig.CurrentPage.As<HomePage>().CheckIfLoginExists();
    }

    [Given(@"I Delete employee '(.*)' before I start running test")]
    public void DBDeleteEmployee(string employeeName)
    {
        string query = $"delete FROM [EAEmployeeDB].[dbo].[Employees] where Name = '{employeeName}'";
        Settings.ApplicationConnection.ExecuteQuery(query);
    }

    [Given(@"I navigate to aplication")]
    public void GivenINavigateToAplication()
    {
        NavigateSite();
    }

    [Given(@"I click the (.*) link")]
    public void GivenIClickTheLink(string linkName)
    {
        if (linkName == "login")
            _parallelConfig.CurrentPage =  _parallelConfig.CurrentPage.As<HomePage>().ClickLoginLink();
        else if (linkName == "employeeList")
            _parallelConfig.CurrentPage =  _parallelConfig.CurrentPage.As<HomePage>().ClickEmployeeList();
    }

    [Given(@"I click (.*) button")]
    public void GivenIClickButton(string button)
    {
        if (button == "login")
           _parallelConfig.CurrentPage =  _parallelConfig.CurrentPage.As<LoginPage>().ClickLoginButton();
        else if (button == "createNew")
            _parallelConfig.CurrentPage =  _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickButtonCreateNew();
        else if (button == "create")
            _parallelConfig.CurrentPage =  _parallelConfig.CurrentPage.As<CreateEmployeePage>().ClickButtonCreate();
    }

    protected ExtendedSteps(ParallelConfig parellelConfig) : base(parellelConfig)
    {
    }
}