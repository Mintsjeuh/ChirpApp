using ChirpApp.Data;
using ChirpApp.Models;
using ChirpApp.Repositories;
using ChirpApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
using System.Runtime.InteropServices;

namespace ChirpApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService) {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Album>>> GetAlbums()
        { 
            var albums = await _albumService.GetAlbums();
            return Ok(albums);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddAlbum(Album? album)
        {
            if (album == null)
            {
                return BadRequest("Can not add null album to database");
            }
            else
            {
                await _albumService.AddAlbum(album);
                return Ok();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            await _albumService.DeleteAlbum(id);
            return Ok();
        }

        [HttpPut("update/{album.Id}")]
        public async Task<ActionResult> UpdateAlbum([FromBody] Album album)
        {
            await _albumService.UpdateAlbum(album);
            return Ok();
        }
    }
}
