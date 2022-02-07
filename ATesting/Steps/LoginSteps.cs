using ATesting.Pages;
using ATFramework.Base;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ATesting;

[Binding]
public class LoginSteps : BaseStep
{
    [Given(@"I navigate to aplication")]
    public void GivenINavigateToAplication()
    {
        CurrentPage = GetInstance<HomePage>();
    }

    [Given(@"I check app opened")]
    public void GivenICheckAppOpened()
    {
        CurrentPage.As<HomePage>().CheckIfLoginExists();
    }

    [Given(@"I click the login link")]
    public void GivenIClickTheLoginLink()
    {
        CurrentPage = CurrentPage.As<HomePage>().ClickLoginLink();
    }

    [Given(@"I enter username and password")]
    public void GivenIEnterUsernameAndPassword(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        CurrentPage.As<LoginPage>().LogIn(data.UserName, data.Password);
    }

    [Given(@"I click login")]
    public void GivenIClickLogin()
    {
        CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
    }

    [Then(@"I should see username with hello")]
    public void ThenIShouldSeeUsernameWithHello()
    {
        if(CurrentPage.As<HomePage>().GetLoogedInUser().Contains("admin"))
            Console.WriteLine("Success login");
        else
            Console.WriteLine("Unsuccess login");
    }
}
