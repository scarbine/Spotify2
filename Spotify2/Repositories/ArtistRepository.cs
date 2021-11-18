using Spotify2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Spotify2.Models;

namespace Spotify2.Repositories
{
    public class ArtistRepository : BaseRepository
    {
        public ArtistRepository(IConfiguration configuration) : base(configuration) { }


        public List<Artist> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = ArtistQuery;
                    var artist = new List<Artist>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        artist.Add(NewArtist(reader));
                    }
                    conn.Close();

                    return artist;
                }
            }
        }

        public Artist GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{ArtistQuery} WHERE s.Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    Artist artist = null;
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        artist = NewArtist(reader);

                    }
                    conn.Close();

                    return artist;
                }
            }
        }



        public void Add(Artist artist)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Artist ( Name)
                                        OUTPUT INSERTED.ID
                                        VALUES ( @Name)";
                    DbUtils.AddParameter(cmd, "@Name", artist.Name);

                    artist.Id = (int)cmd.ExecuteScalar();



                }
            }
        }


        public void Update(Artist artist)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Artist SET 
                                            Name = @Name,
                                            Where Id = @Id";
                    DbUtils.AddParameter(cmd, "@ArtistId", artist.Name);
                    DbUtils.AddParameter(cmd, "@Id", artist.Id);

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
                    cmd.CommandText = "DELETE FROM Artist WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private string ArtistQuery
        {
            get
            {
                return @"SELECT a.Id, a.Name
                        FROM Artist a";
                       
            }
        }

        private Artist NewArtist(SqlDataReader reader)
        {
            return new Artist()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                Name = DbUtils.GetString(reader, "Name"),




            };
        }
    }
}
