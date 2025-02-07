using ChirpApp.Models;
using Microsoft.Extensions.ObjectPool;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<List<Album>> AddAlbum(Album? album)
        {
            if (album != null)
            {
                await _http.PostAsJsonAsync("api/albums/add", album);
            }
            var albums = await _http.GetFromJsonAsync<List<Album>>("api/albums");
            return albums ?? new List<Album>();
        }
    }
}
