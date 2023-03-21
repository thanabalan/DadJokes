using DadJokes.API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DadJokes.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class JokesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public JokesController(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("RapidApi");
        }

        [HttpGet(Name = "GetRandomJoke")]
        public async Task<JokesResponse> GetRandomJoke()
        {
            var response =await _httpClient.GetAsync("random/joke");
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JokesResponse>(body);
            }
            else
            {
                return null;
            }
        }

        [HttpGet(Name = "GetCount")]
        public async Task<JokesResponseCount> GetCount()
        {
            var response = await _httpClient.GetAsync("joke/count");
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JokesResponseCount>(body);
            }
            else
            {
                return null;
            }
        }
    }
}
