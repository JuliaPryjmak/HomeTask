using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace ApiProject.Requests
{
    public class CustomRequests
    {
        private HttpClient Client { get; set; }
        public CustomRequests(HttpClient client)
        {
            Client = client;
        }


        public async Task<ResponseModel<TObject>> Get<TObject>(string endpoint, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> Header in headers)
                {
                    Client.DefaultRequestHeaders.Add(Header.Key, Header.Value);
                }
            }

            HttpResponseMessage httpResponseMessage = await Client.GetAsync(endpoint);
            string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            TObject httpContentObject = (httpResponseMessage.Content.Headers.ContentType == null) ? default : JsonConvert.DeserializeObject<TObject>(result);
            var jsonResponse = await httpResponseMessage.Content.ReadFromJsonAsync<TObject>();

            return new ResponseModel<TObject>
            {
                HttpResponse = httpResponseMessage,
                HttpContentObject = jsonResponse,
                HttpContent = result,
            };
        }

        public async Task<ResponseModel<TObject>> Put<TObject>(string endpoint, string putContent, string mediaType, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> Header in headers)
                {
                    Client.DefaultRequestHeaders.Add(Header.Key, Header.Value);
                }
            }

            StringContent content = new(putContent, Encoding.UTF8, mediaType);
            HttpResponseMessage httpResponseMessage = await Client.PutAsync(endpoint, content);
            string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return new ResponseModel<TObject>
            {
                HttpResponse = httpResponseMessage,
                HttpContent = result
            };
        }
    }
}
