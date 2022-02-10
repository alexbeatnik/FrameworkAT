using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;

namespace ATFramework.Helpers;

public static class ApiHelpers
{
    public static Dictionary<string, string> DeserializeResponse(this IRestResponse restResponse)
    {
        var JSONOBj = new JsonDeserializer().Deserialize<Dictionary<string, string>>(restResponse);
        return JSONOBj;
    }

    public static string GetResponseObject(this IRestResponse response, string responseObject)
    {
        JObject obs = JObject.Parse(response.Content);
        return obs[responseObject].ToString();
    }

    public static async Task<IRestResponse<T>> ExecuteAsyncRequest<T>(this RestClient client, IRestRequest request)
        where T : class, new()
    {
        var taskComplitionSource = new TaskCompletionSource<IRestResponse<T>>();
        client.ExecuteAsync<T>(request, restResponse =>
        {
            if (restResponse.ErrorException != null)
            {
                const string massage = "Error retving responce. ";
                throw new ApplicationException(massage, restResponse.ErrorException);
            }

            taskComplitionSource.SetResult(restResponse);
        });
        return await taskComplitionSource.Task;
    }
}