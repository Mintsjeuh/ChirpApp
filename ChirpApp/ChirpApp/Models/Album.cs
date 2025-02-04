using Microsoft.Extensions.ObjectPool;

namespace ChirpApp.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public string[] Songs { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
