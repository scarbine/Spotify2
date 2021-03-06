using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepository;

        public SongController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_songRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Song song)
        {
            _songRepository.Add(song);
            return CreatedAtAction(nameof(Get), new { id = song.Id }, song);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var album = _songRepository.GetById(id);
            if (album != null)
            {
                NotFound();
            }
            return Ok(album);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _songRepository.Delete(id);
            return NoContent();
        }
    }

}

