using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify2.Repositories;
using Spotify2.Models;

namespace Spotify2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_albumRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Album album)
        {
            _albumRepository.Add(album);
            return CreatedAtAction(nameof(Get), new { id = album.Id }, album);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var album = _albumRepository.GetById(id);
            if(album != null)
            {
                NotFound();
            }
            return Ok(album);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _albumRepository.Delete(id);
            return NoContent();
        }


    }
}
