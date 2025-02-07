using ChirpApp.Models;

namespace ChirpApp.Services
{
    public interface IAlbumService
    {
        Task<List<Album>> GetAlbums();
        Task AddAlbum(Album album);
        Task DeleteAlbum(int id);
        Task UpdateAlbum(Album album);
    }
}
