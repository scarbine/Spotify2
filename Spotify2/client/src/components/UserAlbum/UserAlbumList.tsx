import React, { useEffect, useState } from 'react'
import { UserAlbum } from '../../Interface/Interface';
import { GetAllUserAlbums } from '../../modules/UserAlbumManager';
import { UserAlbumCard } from './UserAlbumCard';


interface UserAlbumListProps {

}

export const UserAlbumList: React.FC<UserAlbumListProps> = ({}) => {

    const [userAlbums, setUserAlbums] = useState<UserAlbum[] | []>([])


        useEffect(()=>{
            GetAllUserAlbums().then(setUserAlbums)
        },[])

        return (
            <>
            {userAlbums?.map(userAlbum => {
                return <UserAlbumCard key={userAlbum.id} userAlbum={userAlbum} />
            })}
            </>
        );
}