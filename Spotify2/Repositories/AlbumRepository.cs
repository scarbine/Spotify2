using Microsoft.Extensions.Configuration;
using Spotify2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spotify2.Models;
using System.Data.SqlClient;

namespace Spotify2.Repositories
{
    public class AlbumRepository : BaseRepository, IAlbumRepository
    {

        public AlbumRepository(IConfiguration configuration) : base(configuration) { }


        public List<Album> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = AlbumQuery;
                    var albums = new List<Album>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        albums.Add(NewAlbum(reader));
                    }
                    conn.Close();

                    return albums;
                }
            }
        }

        public Album GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{AlbumQuery} WHERE s.Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    Album album = null;
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        album = NewAlbum(reader);

                    }
                    conn.Close();

                    return album;
                }
            }
        }



        public void Add(Album album)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Song (Title, ArtistId, SongArtUrl, GenreId)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Title, @ArtistId, @GenreId, @AlbumArtUrl)";
                    DbUtils.AddParameter(cmd, "@Title", album.Title);
                    DbUtils.AddParameter(cmd, "@ArtistId", album.ArtistId);
                    DbUtils.AddParameter(cmd, "@GenreId", album.GenreId);
                    DbUtils.AddParameter(cmd, "@AlbumArtUrl", album.AlbumArtUrl);

                    album.Id = (int)cmd.ExecuteScalar();



                }
            }
        }


        public void Update(Album album)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Song SET 
                                            Title = @Title,
                                            GenreId = @GenreId,
                                            ArtistId = @ArtistId,
                                            AlbumArtUrl = @AlbumArtUrl
                                            Where Id = @Id";
                    DbUtils.AddParameter(cmd, "@Title", album.Title);
                    DbUtils.AddParameter(cmd, "@ArtistId", album.ArtistId);
                    DbUtils.AddParameter(cmd, "@GenreId", album.GenreId);
                    DbUtils.AddParameter(cmd, "@AlbumArtUrl", album.AlbumArtUrl);
                    DbUtils.AddParameter(cmd, "@Id", album.Id);

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
                    cmd.CommandText = "DELETE FROM Album WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private string AlbumQuery
        {
            get
            {
                return @"SELECT a.Id, a.AlbumTitle, a.AlbumArtUrl, a.GenreId,a.ArtistId, a.ReleaseDate,g.Id AS GenreId, g.GenreName, art.Id AS ArtistId, art.Name AS ArtistName
                        FROM Album a
                        LEFTJOIN Genre g ON g.Id = a.GenreId
                        LEFTJOIN Artist art ON art.Id = a.ArtistId";
            }
        }

        private Album NewAlbum(SqlDataReader reader)
        {
            return new Album()
            {
                Id = DbUtils.GetInt(reader, "Id"),
                GenreId = DbUtils.GetInt(reader, "GenreId"),
                ArtistId = DbUtils.GetInt(reader, "ArtistId"),
                AlbumArtUrl = DbUtils.GetString(reader, "AlbumArturl"),
                Genre = new Genre()
                {
                    Id = DbUtils.GetInt(reader, "GenreId"),
                    GenreName = DbUtils.GetString(reader, "GenreName")

                },
                Artist = new Artist()
                {
                    Id = DbUtils.GetInt(reader, "Artistid"),
                    Name = DbUtils.GetString(reader, "ArtistName")


                }


            }
        }
    }
}
