using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify2.Models;
using System.Data.SqlClient;
using Spotify2.Utils;

namespace Spotify2.Repositories
{
    public class SongRepository : BaseRepository, ISongRepository
    {
        public SongRepository(IConfiguration configuration) : base(configuration) { }


        public List<Song> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = SongQuery;
                    var songs = new List<Song>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        songs.Add(NewSong(reader));
                    }
                    conn.Close();

                    return songs;
                }
            }
        }

        public Song GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SongQuery} WHERE s.Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    Song song = null;
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        song = NewSong(reader);

                    }
                    conn.Close();

                    return song;
                }
            }
        }

        public List<Song> GetByAlbumId(int albumId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{SongQuery} WHERE s.AlbumId = @AlbumId";
                    DbUtils.AddParameter(cmd, "@AlbumId", albumId);
                    var songs = new List<Song>();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        songs.Add(NewSong(reader));
                    }

                    conn.Close();
                    return songs;
                }
            }
        }

        public void Add(Song song)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Song (Title, Length, SongArtUrl, AlbumId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Title, @Length, @SongArtUrl, @AlbumId)";
                    DbUtils.AddParameter(cmd, "@Title", song.Title);
                    DbUtils.AddParameter(cmd, "@Length", song.Length);
                    DbUtils.AddParameter(cmd, "@SongArtUrl", song.SongArtUrl);
                    DbUtils.AddParameter(cmd, "@AlbumId", song.AlbumId);

                    song.Id = (int)cmd.ExecuteScalar();



                }
            }
        }


        public void Update(Song song)
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
                    DbUtils.AddParameter(cmd, "@Title", song.Title);
                    DbUtils.AddParameter(cmd, "@Length", song.Length);
                    DbUtils.AddParameter(cmd, "@SongArtUrl", song.SongArtUrl);
                    DbUtils.AddParameter(cmd, "@AlbumId", song.AlbumId);
                    DbUtils.AddParameter(cmd, "@Id", song.Id);

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
                    cmd.CommandText = "DELETE FROM Song WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private string SongQuery
        {
            get
            {
                return @"SELECT s.Id, s.Title, s.Length, s.SongArtUrl, s.AlbumId, a.Id, a.AlbumTitle, a.AlbumArtUrl, a.GenreId,a.ArtistId, a.ReleaseDate,g.Id, g.GenreName, art.Id AS ArtistArtistId, art.Name AS ArtistName
                        FROM Song s 
                        LEFTJOIN Album a ON s.AlbumId = a.Id 
                        LEFTJOIN Genre g ON g.Id = a.GenreId
                        LEFTJOIN Artist art ON art.Id = a.ArtistId";
            }
        }

        private Song NewSong(SqlDataReader reader)
        {
            return new Song()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                Title = DbUtils.GetString(reader, "Title"),
                Length = DbUtils.GetInt(reader, "Length"),
                SongArtUrl = DbUtils.GetString(reader, "SongArtUrl"),
                AlbumId = DbUtils.GetInt(reader, "AlbumId"),
                Album = new Album()
                {
                    Id = DbUtils.GetInt(reader, "Id"),
                    Title = DbUtils.GetString(reader, "AlbumTitle"),
                    AlbumArtUrl = DbUtils.GetString(reader, "AlbumArtUrl"),
                    GenreId = DbUtils.GetInt(reader, "GenreId"),
                    ReleaseDate = DbUtils.GetDateTime(reader, "ReleaseDate"),
                    Genre = new Genre()
                    {
                        Id = DbUtils.GetInt(reader, "Id"),
                        GenreName = DbUtils.GetString(reader, "GenreName")
                    },
                    ArtistId = DbUtils.GetInt(reader, "ArtistId"),
                    Artist = new Artist()
                    {
                        Id = DbUtils.GetInt(reader, "ArtistArtistId"),
                        Name = DbUtils.GetString(reader, "ArtistName")
                    }

                }
            };
        }
    }
}
