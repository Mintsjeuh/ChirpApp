using ChirpApp.Data;
using ChirpApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChirpApp.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _context;

        public AlbumRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetAlbums()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task AddAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAlbum(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }
    }

}
