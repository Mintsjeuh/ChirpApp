using Microsoft.Extensions.ObjectPool;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChirpApp.Models
{
    public class Album
    {
        [Key] // Marks this as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increments the Id
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public string[] Songs { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
