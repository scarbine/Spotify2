using Spotify2.Models;
using System.Collections.Generic;

namespace Spotify2.Repositories
{
    public interface IArtistRepository
    {
        void Add(Artist artist);
        void Delete(int id);
        List<Artist> GetAll();
        Artist GetById(int id);
        void Update(Artist artist);
    }
}