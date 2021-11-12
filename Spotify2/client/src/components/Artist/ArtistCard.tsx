import React from "react";
import { Artist } from "../../Interface/Interface";

interface ArtistCardProps {
  artist: Artist;
}

export const ArtistCard: React.FC<ArtistCardProps> = ({ artist }) => {
  return (
    <>
      <div>{artist.id}</div>
      <div>{artist.name}</div>
    </>
  );
};
