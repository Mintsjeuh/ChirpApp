using ChirpApp.Models;
using Microsoft.Extensions.ObjectPool;
using System.Net.Http;
using System.Text;

namespace ChirpApp.Services
{
    public class AlbumService
    {
        private readonly HttpClient _http;

        public AlbumService(HttpClient http)
        {
            _http = http;
        }
        
        public async Task<List<Album>> GetAlbums()
        {
            var albums = await _http.GetFromJsonAsync<List<Album>>("api/albums");
            return albums ?? new List<Album>();
        }
    }
}
