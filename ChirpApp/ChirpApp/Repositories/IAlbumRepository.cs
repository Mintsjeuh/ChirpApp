using ChirpApp.Models;

namespace ChirpApp.Repositories
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetAlbums();
        Task AddAlbum(Album album);
        Task DeleteAlbum(int id);
        Task UpdateAlbum(Album album);
    }
}
