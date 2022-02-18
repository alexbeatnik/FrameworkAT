using ATesting.Pages;
using ATFramework.Base;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ATesting;

[Binding]
public class LoginSteps : BaseStep
{
    [Given(@"I enter username and password")]
    public void GivenIEnterUsernameAndPassword(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        _parallelConfig.CurrentPage.As<LoginPage>().LogIn(data.UserName, data.Password);
    }

    [Then(@"I should see username with hello")]
    public void ThenIShouldSeeUsernameWithHello()
    {
        if (_parallelConfig.CurrentPage.As<HomePage>().GetLoogedInUser().Contains("admin"))
            Console.WriteLine("Success login");
        else
            Console.WriteLine("Unsuccess login");
    }

    protected LoginSteps(ParallelConfig parellelConfig) : base(parellelConfig)
    {
    }
}