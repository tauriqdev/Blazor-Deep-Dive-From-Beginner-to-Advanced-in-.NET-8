using Newtonsoft.Json;
using System.Text;

namespace WebAssemblyDemo.Client.Models
{
    public class ServersApiRepository : IServersRepository
    {
        private const string _apiName = "ServersApi";
        private readonly IHttpClientFactory _httpClientFactory;

        public ServersApiRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Server>> GetServersAsync()
        {
            var httpClient = _httpClientFactory.CreateClient(_apiName);

            var response = await httpClient.GetAsync("servers.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            // only for firebase
            if (!string.IsNullOrEmpty(content) && content != "null")
            {
                return JsonConvert.DeserializeObject<List<Server>>(content) ?? [];
            }

            return new List<Server>();
        }

        public async Task AddServerAsync(Server server)
        {
            server.Id = await GetNextServerIsAsync();

            var httpClient = _httpClientFactory.CreateClient(_apiName);
            var content = new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"servers/{server.Id}.json", content);
            response.EnsureSuccessStatusCode();
        }

        private async Task<int> GetNextServerIsAsync()
        {
            var servers = await GetServersAsync();
            if (servers is not null && servers.Any())
            {
                return servers.Where(x => x is not null).Max(x => x.Id) + 1;
            }

            return 1;
        }
    }
}
