using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;

namespace Reviewer.Services.Implemintations
{
    public class ReviewerApiService
    {
        private readonly HttpClient _client;
        public ReviewerApiService(HttpClient client, IConfiguration conf)
        {
            _client = client;
            _client.BaseAddress = new Uri(conf["ReviewerApiBaseUrl"]);
        }

        public async Task<object> GetAsync(string url, Type responseType)
        {
            var response = await _client.GetAsync(url);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Error while trying send Get request with url : {url} \n : \"{await response.Content.ReadAsStringAsync()}\" ");
            }

            var result = await response.Content.ReadFromJsonAsync(responseType);

            return result;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var result = (T)await GetAsync(url, typeof(T));

            return result;
        }

        public async Task<object> PostAsync(string url, object body, Type responseType)
        {
            var response = await _client.PostAsJsonAsync(url, body);

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            var result = await response.Content.ReadFromJsonAsync(responseType);

            return result;
        }
    }
}
