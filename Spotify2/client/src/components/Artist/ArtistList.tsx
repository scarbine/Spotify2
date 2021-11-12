import React, { useEffect, useState } from "react";
import { Artist } from "../../Interface/Interface";
import { GetAllArtist } from "../../modules/Artistmanager";
import { ArtistCard } from "./ArtistCard";

interface ArtistListProps {}

export const ArtistList: React.FC<ArtistListProps> = () => {
  const [artist, setArtist] = useState<Artist[] | []>([]);

  useEffect(() => {
    GetAllArtist().then(setArtist);
  }, []);

  return (
    <>
      {artist?.map((art) => {
        return <ArtistCard key={art.id} artist={art} />;
      })}
    </>
  );
};
