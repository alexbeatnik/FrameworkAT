using ATesting.Pages;
using ATFramework.Base;
using TechTalk.SpecFlow;

namespace ATesting.Steps;

[Binding]
public class ExtendedSteps : BaseStep
{
    [Given(@"I check app opened")]
    public void GivenICheckAppOpened()
    {
        CurrentPage.As<HomePage>().CheckIfLoginExists();
    }

    [Given(@"I navigate to aplication")]
    public void GivenINavigateToAplication()
    {
        CurrentPage = GetInstance<HomePage>();
    }

    [Given(@"I click the (.*) link")]
    public void GivenIClickTheLink(string linkName)
    {
        if (linkName == "login")
            CurrentPage = CurrentPage.As<HomePage>().ClickLoginLink();
        else if (linkName == "employeeList")
            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
    }

    [Given(@"I click (.*) button")]
    public void GivenIClickButton(string button)
    {
        if (button == "login")
            CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
        else if (button == "createNew")
            CurrentPage = CurrentPage.As<EmployeeListPage>().ClickButtonCreateNew();
        else if (button == "create")
            CurrentPage = CurrentPage.As<CreateEmployeePage>().ClickButtonCreate();
    }
}