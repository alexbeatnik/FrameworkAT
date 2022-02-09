using ATesting.Model;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace ATesting
{
    internal class ApiTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ApiTestOperation()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("post/{postid}", Method.GET);
            request.AddUrlSegment("{postid}", 1);
            var response = client.Execute(request);
            // var deserialize = new JsonDeserializer();
            // var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            // var result = output["author"];

            JObject obs = JObject.Parse(response.Content);
            Assert.AreEqual(obs["author"], "alexbeatnik", "Author is not correct");
        }

        [Test]
        public void PostWithAnonymoysBody()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("post/{postid}/profile", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new {name = "Vsiliy"});
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.AreEqual(obs["name"], "Vsiliy", "Name is not correct");
        }

        [Test]
        public void PostWithTypeClassBody()
        {
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("poss", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Posts() {id = "13", author = "Automation", title = "RestSharpDemo"});

            var response = client.Execute(request);

            JObject obs = JObject.Parse(response.Content);
            Assert.AreEqual(obs["author"], "Automation", "Author is not correct");
        }
    }
}