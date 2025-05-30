using System.Net.Http.Json;
using LCWeb.Shared.DTOs.DraftLCDTO;

namespace LCWeb.Client.Services.ClientDraftLCService
{
    public class ClientDraftLCService : IClientDraftLCService
    {
        private readonly HttpClient _http;

        public ClientDraftLCService(HttpClient http)
        {
            _http = http;
        }

        public async Task<int> CreateDraftLC(CreateDraftLCSectionDTO payload)
        {
            HttpResponseMessage? response = await _http.PostAsJsonAsync("api/draftlc/add-entry", payload);
            if (response.IsSuccessStatusCode)
            {
                int result = await response.Content.ReadFromJsonAsync<int>();
                return result == 0 ? 0 : result;
            }
            else
            {
                return 0;
            }
        }

    }
}
