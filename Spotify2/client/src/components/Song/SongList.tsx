import React, { useEffect, useState } from "react";
import { GetAllSongs } from "../../modules/SongManager";
import { Song } from "../../Interface/Interface";
import { SongCard } from "./SongCard";


export const SongList: React.FC = () => {

    const [songs , setSongs] = useState<Song[] | []>([])


    useEffect(()=>{
        GetAllSongs().then(setSongs)
    },[])

    return(
        <>
            <h1>Song List</h1>
            {songs.map((song: Song)  => {
                return <SongCard key={song.id} song={song} />
            })}
        </>
    )
}

