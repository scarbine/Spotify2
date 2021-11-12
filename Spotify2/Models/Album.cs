using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify2.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AlbumArtUrl { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set;  }

        public int GenreId { get; set;  }

        public Genre Genre { get; set;  }

        public DateTime releaseDate { get; set; }

        public List<Song> Songs { get; set; }
    }
}
