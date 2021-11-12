import React from 'react'
import { Album } from '../../Interface/Interface';

interface AlbumCardProps {
    album:Album;
}

export const AlbumCard: React.FC<AlbumCardProps> = ({album}) => {
        return (
            <>
                <div>{album.id}</div>
                <div>{album.artistId}</div>
                <div>{album.genreId}</div>
                <div>{album.title}</div>
            </>
        );
}