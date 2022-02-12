using ATesting.Pages;
using ATFramework.Base;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ATesting.Steps
{
    [Binding]
    public class CreateEmployeeSteps : Base
    {
        [Given(@"I enter following details")]
        public CreateEmployeeSteps GivenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            CurrentPage.As<CreateEmployeePage>().CreateEmployee(data.Name, data.Salary.ToString(),
                data.DurationWorked.ToString(), data.Grade.ToString(), data.Email);
            return this;
        }
    }
}