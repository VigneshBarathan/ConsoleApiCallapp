using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace ConsoleApiCallapp
{
    public class ApiHelper
    {
        public async Task<ChuckNorrisJoke> ApiCall()
        {
            var services = new ServiceCollection();
            services.AddHttpClient<ChuckNorrisClient>(c => c.BaseAddress = new Uri("https://api.chucknorris.io/"));
            var serviceProvider = services.BuildServiceProvider();

            var client = serviceProvider.GetService<ChuckNorrisClient>();
            var response =  client.GetRandomJokeAsync();

            return await response;
        }
    }

    public record ChuckNorrisJoke(string Id, string Value, string Url);
    
    public class ChuckNorrisClient
    {
        private readonly HttpClient _httpClient;

        public ChuckNorrisClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<ChuckNorrisJoke> GetRandomJokeAsync() => await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>("jokes/random");
    }
}
