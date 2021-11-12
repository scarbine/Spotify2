using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify2.Models
{
    public class UserAlbum
    {
        public int Id { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
