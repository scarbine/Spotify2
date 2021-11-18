using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify2.Repositories;
using Spotify2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Spotify2.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private readonly IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_artistRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Post(Artist artist)
        {
            _artistRepository.Add(artist);
            return CreatedAtAction(nameof(Get), new { id = artist.Id }, artist);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var album = _artistRepository.GetById(id);
            if (album != null)
            {
                NotFound();
            }
            return Ok(album);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _artistRepository.Delete(id);
            return NoContent();
        }
    }
}
