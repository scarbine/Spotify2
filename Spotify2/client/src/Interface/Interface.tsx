import React from "react";

export interface Song {
  id: number;
  title: string;
  length: number;
  albumId: number;
  songArtUrl: string;
  album: Album;
}

export interface Album {
  id: number;
  title: string;
  artistId: number;
  genreId: number;
  albumArtUrl: string;
  artist: Artist;
  genre: Genre;
}

export interface Artist {
  id: number;
  name: string;
}

export interface Genre {
  id: number;
  genre: string;
}

export interface UserAlbum {
  id: number;
  albumId: number;
  album: Album;
  userId: number;
  user: User;
}

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  firebaseId: string;
  birthday: string;
  userName: string;
  country: string;
  state: string;
  city: string;
  profilePicUrl: string;
}
