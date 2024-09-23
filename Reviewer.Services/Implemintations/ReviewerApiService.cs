using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Reviewer.Services.Models;
using Reviewer.Services.Models.Admin.Attributes;

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

        public Task<object> Create(object create, Type responseType)
        {
            var apiPath = create.GetType().GetCustomAttribute<AdminCreateTypeApiNameAttribute>()?.Name;

            if (string.IsNullOrEmpty(apiPath))
            {
                throw new ArgumentException($"object {create} doesn`t contain {nameof(AdminCreateTypeApiNameAttribute)}!");
            }

            return PostAsync($"admin/{apiPath}", create, responseType);
        }

        public async Task<ListData> GetList(RequestFilters filters, Type responseEntityType)
        {
            var apiPath = responseEntityType.GetCustomAttribute<AdminResponseTypeApiNameAttribute>()?.Name;
            var responseType = typeof(ListData<>).MakeGenericType(responseEntityType);
            var url = $"admin/{apiPath}?page={filters.Page}&count={filters.Count}" +
                (filters.Order != null ? $"&order.orderby={filters.Order?.OrderBy}&order.isdescending={filters.Order?.IsDescending}" : "") +
                $"&search={filters.Search}";

            var listDataWithType = await GetAsync(url, responseType);
            var listData = (ListData)responseType.GetMethod("GetListData").Invoke(listDataWithType, null);

            return listData;
        }

        //public async Task<IActionResult> Update(TUpdate update)
        //{
        //    var entity = await _service.Update(update);

        //    return Ok(entity);
        //}

        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var entity = await _service.Get(id);

        //    return Ok(entity);
        //}

        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    await _service.Delete(id);

        //    return NoContent();
        //}
    }
}
