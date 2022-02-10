using ATesting.Model;
using ATFramework.Helpers;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace ATesting.Steps;

[Binding]
public class GetPostsSteps
{
    public RestClient client = new RestClient("http://localhost:3000/");
    public RestRequest request = new RestRequest();
    public IRestResponse<Posts> responce = new RestResponse<Posts>();

    [Given(@"I perform GET operation for ""(.*)""")]
    public void GivenIPerformGetOperationFor(string url)
    {
        request = new RestRequest(url, Method.GET);
    }

    [Given(@"I perform operation for post ""(.*)""")]
    public void GivenIPerformOperationForPost(int postId)
    {
        request.AddUrlSegment("postid", postId.ToString());
        responce = client.ExecuteAsyncRequest<Posts>(request).GetAwaiter().GetResult();
    }

    [Then(@"I should see the ""(.*)"" name as ""(.*)""")]
    public void ThenIShouldSeeTheNameAs(string key, string value)
    {
        Assert.That(responce.GetResponseObject(key), Is.EqualTo(value), $"The {key} is not matching");
    }
}