using ChirpApp.Models;

namespace ChirpApp.Services
{
    public interface IAlbumFilterService
    {
        List<Album> FilterAlbums(List<Album> albums, string searchTerm);
    }
}
