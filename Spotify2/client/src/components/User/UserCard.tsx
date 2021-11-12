import React from 'react'
import {User} from "../../Interface/Interface"

interface UserCardProps {
    user: User;
}

export const UserCard: React.FC<UserCardProps> = ({user}) => {
        return (
        <>
        <div>{user.id}</div>
        <div>{user.firstName}</div>
        <div>{user.lastName}</div>
        <div>{user.email}</div>
        <div>{user.city}</div>
        <div>{user.country}</div>
        <div>{user.state}</div>
        <div>{user.birthday}</div>
        <div>{user.userName}</div>
        </>
        );
}