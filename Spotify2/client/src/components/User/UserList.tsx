import React, { useEffect, useState } from 'react'
import {User} from "../../Interface/Interface"
import { GetAllUsers } from '../../modules/Usermanager';
import { UserCard } from './UserCard';

interface UserListProps {

}

export const UserList: React.FC<UserListProps> = ({}) => {

    const[users, setUsers] = useState<User[] | []>()

    useEffect(()=>{
        GetAllUsers().then(setUsers)
    },[])
    
        return (

            <>
                {users?.map(user=> {
                    return <UserCard key={user.id} user={user} />
                })}
            </>
        );
}