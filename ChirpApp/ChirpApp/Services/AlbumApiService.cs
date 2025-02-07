using ChirpApp.Models;

namespace ChirpApp.Services
{
    public class AlbumApiService : IAlbumApiService
    {
        private readonly HttpClient _http;

        public AlbumApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await _http.GetFromJsonAsync<List<Album>>("api/albums") ?? new List<Album>();
        }

        public async Task<bool> AddAlbum(Album album)
        {
            var response = await _http.PostAsJsonAsync("api/albums/add", album);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAlbum(Album album)
        {
            var response = await _http.PutAsJsonAsync($"api/albums/update/{album.Id}", album);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAlbum(int id)
        {
            var response = await _http.DeleteAsync($"api/albums/delete/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
