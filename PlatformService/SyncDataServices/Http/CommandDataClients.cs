
using PlatformService.Dtos;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace PaltformService.SyncDataServices.Http
{
    public class  HttpCommandDataClient : ICommandDataClients
    {
        private HttpClient _httpClient;
        private IConfiguration _config;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;

        }

        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpcontent = new StringContent(JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync(_config["CommandServices"],httpcontent);
            if (response.IsSuccessStatusCode)
            {

                Console.WriteLine("--> Sync post to command was ok!");
            }
            else {
                Console.WriteLine("--> Sync post to command was ko!");
            }

        }


            
    }

}