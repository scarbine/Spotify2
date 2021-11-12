using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify2.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SongArtUrl { get; set; }

        public int Length { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }


    }
}
