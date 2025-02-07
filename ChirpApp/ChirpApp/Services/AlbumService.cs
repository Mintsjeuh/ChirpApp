using ChirpApp.Models;
using ChirpApp.Repositories;

namespace ChirpApp.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await _albumRepository.GetAlbums();
        }

        public async Task AddAlbum(Album album)
        {
            if (string.IsNullOrWhiteSpace(album.AlbumName))
            {
                throw new ArgumentException("Album name is required");
            }

            await _albumRepository.AddAlbum(album);
        }

        public async Task DeleteAlbum(int id)
        {
            await _albumRepository.DeleteAlbum(id);
        }

        public async Task UpdateAlbum(Album album)
        {
            await _albumRepository.UpdateAlbum(album);
        }
    }

}
