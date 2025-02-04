using ChirpApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ChirpApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Album> Albums { get; set; }


    }
}
