using ChirpApp.Components.Pages;
using ChirpApp.Models;

namespace ChirpApp.Services
{
    public class AlbumFilterService : IAlbumFilterService
    {
        public AlbumFilterService() { }

        public List<Album> FilterAlbums(List<Album> albums, string searchTerm)
        {
            return albums = albums
                .Where(a => (
                    a.Artist.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    a.AlbumName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    a.Songs.Any(song => (song.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                    ))
                .OrderByDescending(a => a.ReleaseDate)
                .ToList();
        }
    }
}
