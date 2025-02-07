using ChirpApp.Models;

namespace ChirpApp.Services
{
    public interface IAlbumApiService
    {
        Task<List<Album>> GetAlbums();
        Task<bool> AddAlbum(Album album);
        Task<bool> UpdateAlbum(Album album);
        Task<bool> DeleteAlbum(int id);
    }
}
