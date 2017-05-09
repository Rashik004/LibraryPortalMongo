using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CompanyName.ClientManager
{
    public class JsonClientManager
    {
        private readonly HttpClient _client;

        public JsonClientManager(string baseUrl,string acceptedHeader= "application/json")
        {
            _client = new HttpClient {BaseAddress = new Uri(baseUrl)};
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptedHeader));
        }

        public async Task<HttpResponseMessage> GetRequest(string url)
        {
            var res = await _client.GetAsync(url);
            return res;
        }

        //public async Task<HttpResponseMessage> PutRequest(on) 
    }
}
