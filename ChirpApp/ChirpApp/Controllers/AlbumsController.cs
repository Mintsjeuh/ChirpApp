using ChirpApp.Data;
using ChirpApp.Models;
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
        private readonly AppDbContext _appDbContext;

        public AlbumsController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Album>> Get()
        {
            var albums = _appDbContext.Albums;
            return Ok(albums);
        }
    }
}
