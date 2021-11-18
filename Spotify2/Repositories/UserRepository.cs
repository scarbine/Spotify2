using Microsoft.Extensions.Configuration;
using Spotify2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Spotify2.Models;

namespace Spotify2.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(IConfiguration configuration) : base(configuration) { }


        public List<User> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = UserQuery;
                    var users = new List<User>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(NewUser(reader));
                    }
                    conn.Close();

                    return users;
                }
            }
        }

        public User GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{UserQuery} WHERE s.Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    User user = null;
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        user = NewUser(reader);

                    }
                    conn.Close();

                    return user;
                }
            }
        }



        public void Add(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Song (FIrstName, LastName, Email, FirebaseId, Birthday, Username, Country, State, City, ProfilePicUrl)
                                        OUTPUT INSERTED.ID
                                        VALUES (@firstName, @lastName, @email, @firebaseId, @birthday, @username, @country, @state, @city, @profilePicUrl)";
                    DbUtils.AddParameter(cmd, "@firstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@lastname", user.LastName);
                    DbUtils.AddParameter(cmd, "@email", user.Email);
                    DbUtils.AddParameter(cmd, "@firebaseId", user.FirebaseId);
                    DbUtils.AddParameter(cmd, "@birthday", user.Birthday);
                    DbUtils.AddParameter(cmd, "@userName", user.UserName);
                    DbUtils.AddParameter(cmd, "@country", user.Country);
                    DbUtils.AddParameter(cmd, "@state", user.State);
                    DbUtils.AddParameter(cmd, "@city", user.City);
                    DbUtils.AddParameter(cmd, "@profilePicUrl", user.ProfilePicUrl);




                    user.Id = (int)cmd.ExecuteScalar();



                }
            }
        }


        public void Update(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Song SET 
                                            Title = @Title,
                                            Length = @Length,
                                            SongArtUrl = @SongArtUrl,
                                            AlbumId = @AlbumId
                                            Where Id = @Id";
                    DbUtils.AddParameter(cmd, "@firstName", user.FirstName);
                    DbUtils.AddParameter(cmd, "@lastname", user.LastName);
                    DbUtils.AddParameter(cmd, "@email", user.Email);
                    DbUtils.AddParameter(cmd, "@firebaseId", user.FirebaseId);
                    DbUtils.AddParameter(cmd, "@birthday", user.Birthday);
                    DbUtils.AddParameter(cmd, "@userName", user.UserName);
                    DbUtils.AddParameter(cmd, "@country", user.Country);
                    DbUtils.AddParameter(cmd, "@state", user.State);
                    DbUtils.AddParameter(cmd, "@city", user.City);
                    DbUtils.AddParameter(cmd, "@profilePicUrl", user.ProfilePicUrl);
                    DbUtils.AddParameter(cmd, "@Id", user.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM USer WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private string UserQuery
        {
            get
            {
                return @"SELECT u.Id, u.firstName, u.lastName, u.email, u. firebaseId, u.birthday, u.userName, u.country, u.state, u.city, u.profilePicUrl, 
                        FROM User u ";

            }
        }

        private User NewUser(SqlDataReader reader)
        {
            return new User()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                FirstName = DbUtils.GetString(reader, "firstName"),
                LastName = DbUtils.GetString(reader, "lastName"),
                FirebaseId = DbUtils.GetString(reader, "FirebaseId"),
                Email = DbUtils.GetString(reader, "email"),
                Birthday = DbUtils.GetDateTime(reader, "birthday"),
                UserName = DbUtils.GetString(reader, "userName"),
                Country = DbUtils.GetString(reader, "country"),
                State = DbUtils.GetString(reader, "state"),
                City = DbUtils.GetString(reader, "city"),
                ProfilePicUrl = DbUtils.GetString(reader, "profilePicUrl")
            };
        }
    }
}

