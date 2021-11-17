using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify2.Repositories;

namespace Spotify2.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongRepository _songRepositor;
        private readonly IUserRepository _userRepository;

        public SongController(
            ISongRepository songRepository,
            )

    }
}
