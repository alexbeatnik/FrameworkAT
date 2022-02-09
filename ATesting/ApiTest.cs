using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var request = new RestRequest("post/{postid}", Method.Get);
            request.AddUrlSegment("{postid}", 1);
            var content = client.ExecuteGetAsync(request).Result;
            Console.WriteLine(content); 
        }


        }
}
