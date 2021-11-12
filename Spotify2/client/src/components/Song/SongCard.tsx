import React from "react";
import { Song } from "../../Interface/Interface";


interface Props  {
    song: Song;
}

export const SongCard: React.FC<Props> = ({song}) => {
  return (
    <>
      <div>{song.id}</div>
      <div>{song.title}</div>
      <div>{song.length}</div>
      <div>{song.songArtUrl}</div>
      <div>{song.albumId}</div>
    </>
  );
};
