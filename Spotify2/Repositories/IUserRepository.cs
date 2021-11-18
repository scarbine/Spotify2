using Spotify2.Models;
using System.Collections.Generic;

namespace Spotify2.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(int id);
        List<User> GetAll();
        User GetById(int id);
        void Update(User user);
    }
}