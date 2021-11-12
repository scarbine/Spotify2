import { userInfo } from 'os'
import React, { useEffect, useState } from 'react'
import { getAllJSDocTags } from 'typescript'
import { Album } from '../../Interface/Interface'
import { GetAllAlbums } from '../../modules/Albummanager'
import { AlbumCard } from './AlbumCard'

interface AlbumListProps {

}

export const AlbumList: React.FC<AlbumListProps> = ({}) => {

    const [albums , setAlbums] = useState<Album[] | []>([])

    useEffect(()=>{
        GetAllAlbums().then(setAlbums)
    },[])

        return (
            <>
                {albums?.map(album => {
                    return <AlbumCard key={album.id} album={album} />
                })}
            </>
        );
}