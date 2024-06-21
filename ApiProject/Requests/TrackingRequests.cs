using ApiProject.Models.Deserialize;
using ApiProject.Models.Serialize;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace ApiProject.Requests
{
    public class TrackingRequests
    {
        private CustomRequests Request { get; set; }
        private string Url { get; set; }
        private HttpClient Client { get; set; }

        public TrackingRequests(string url, HttpClient client)
        {
            Url = url;
            Client = client;
            Request = new CustomRequests(client);
        }
    

        public ResponseModel<IList<DLoginFail>> GetLoginFailTotal(string username = null, int? faiCount = null, int? fetchLimit = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var Response = Request.Get<IList<DLoginFail>>($"api/loginfailtotal?username={username}&faiCount={faiCount}&fetchLimit={fetchLimit}").Result;

            Assert.That(Response.HttpResponse.StatusCode, Is.EqualTo(statusCode), $"The {MethodBase.GetCurrentMethod().Name} StatusCodes do not match.");

            return Response;
        }

        public ResponseModel<string> PutResetLoginFailTotal(SResetLoginFailTotal resetLoginFailBody, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var Response = Request.Put<string>($"api/resetloginfailtotal", JsonConvert.SerializeObject(resetLoginFailBody), "application/json").Result;

            Assert.That(Response.HttpResponse.StatusCode, Is.EqualTo(statusCode), $"The {MethodBase.GetCurrentMethod().Name} StatusCodes do not match.");

            return Response;
        }
    }   
}
