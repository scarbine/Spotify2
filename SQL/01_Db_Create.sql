USE [master]

IF db_id('Spotify2') IS NULL
	CREATE DATABASE [Spotify2]

GO

USE [Spotify2]

GO

DROP TABLE IF EXISTS [Song]
DROP TABLE IF EXISTS [Album]
DROP TABLE IF EXISTS [User]
DROP TABLE IF EXISTS [UserAlbum]
DROP TABLE IF EXISTS [Genre]



CREATE TABLE [Song] (
  [id] int PRIMARY KEY,
  [title] nvarchar(255),
  [length] int,
  [albumId] int,
  [songArtUrl] nvarchar(255),
  [releaseDate] date
)
GO

CREATE TABLE [Album] (
  [id] int PRIMARY KEY,
  [title] nvarchar(255),
  [artistId] int,
  [genreId] int,
  [albumArtUrl] nvarchar(255)
)
GO

CREATE TABLE [Artist] (
  [id] int PRIMARY KEY,
  [name] nvarchar(255)
)
GO

CREATE TABLE [Genre] (
  [id] int PRIMARY KEY,
  [genre] nvarchar(255)
)
GO

CREATE TABLE [User] (
  [id] int PRIMARY KEY,
  [firstName] nvarchar(255),
  [lastName] nvarchar(255),
  [email] nvarchar(255),
  [firebaseId] nvarchar(255),
  [birthday] date,
  [userName] nvarchar(255),
  [country] nvarchar(255),
  [state] nvarchar(255),
  [city] nvarchar(255),
  [profilePicUrl] nvarchar(255)
)
GO

CREATE TABLE [UserAlbum] (
  [id] int PRIMARY KEY,
  [albumId] int,
  [userId] int
)
GO

ALTER TABLE [Song] ADD FOREIGN KEY ([albumId]) REFERENCES [Album] ([id])
GO

ALTER TABLE [Album] ADD FOREIGN KEY ([artistId]) REFERENCES [Artist] ([id])
GO

ALTER TABLE [Album] ADD FOREIGN KEY ([genreId]) REFERENCES [Genre] ([id])
GO

ALTER TABLE [UserAlbum] ADD FOREIGN KEY ([albumId]) REFERENCES [Album] ([id])
GO

ALTER TABLE [UserAlbum] ADD FOREIGN KEY ([userId]) REFERENCES [User] ([id])
GO

