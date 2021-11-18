using Spotify2.Models;
using System.Collections.Generic;

namespace Spotify2.Repositories
{
    public interface IAlbumRepository
    {
        void Add(Album album);
        void Delete(int id);
        List<Album> GetAll();
        Album GetById(int id);
        void Update(Album album);
    }
}