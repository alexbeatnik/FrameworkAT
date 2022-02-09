using NUnit.Framework;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using Dynamitey.DynamicObjects;
using RestSharp.Deserializers;


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
            var deserialize = new JsonDeserializer();
            deserialize.Deserialize<Dictionary<string, string>>(response);
        }
    }
}