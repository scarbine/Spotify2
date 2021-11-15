import React from 'react'
import { UserAlbum } from '../../Interface/Interface';

interface UserAlbumCardProps {
userAlbum: UserAlbum;
}

export const UserAlbumCard: React.FC<UserAlbumCardProps> = ({userAlbum}) => {
        return (
            <>
            <div>{userAlbum.albumId}</div>
            <div>{userAlbum.userId}</div>
            <div>{userAlbum.id}</div>
            </>
        );
}