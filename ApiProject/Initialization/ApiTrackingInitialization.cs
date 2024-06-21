using ApiProject.Requests;
namespace ApiProject.Initialization
{
    [TestFixture]
    public class ApiTrackingInitialization
    {
        public ApiTrackingInitialization()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Configuration.Url);

            TrackingRequests = new TrackingRequests(Configuration.Url, Client);
            RequestBuilder = new RequestBuilder();
        }

        private HttpClient Client { get; set; }
        public TrackingRequests TrackingRequests { get; set; }
        public RequestBuilder RequestBuilder { get; set; }
    }
}
