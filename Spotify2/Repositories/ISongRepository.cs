using Spotify2.Models;
using System.Collections.Generic;

namespace Spotify2.Repositories
{
    public interface ISongRepository
    {
        void Add(Song song);
        void Delete(int id);
        List<Song> GetAll();
        List<Song> GetByAlbumId(int albumId);
        Song GetById(int id);
        void Update(Song song);
    }
}