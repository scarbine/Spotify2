import React, { useEffect, useState } from 'react'
import { Genre } from "../../Interface/Interface";
import { GetAllGenres } from '../../modules/GenreManager';
import { GenreCard } from './GenreCard';

interface GenreListProps {

}

export const GenreList: React.FC<GenreListProps> = ({}) => {

    const [genres, setGenres ] = useState<Genre[] | []>()

    useEffect(()=>{
            GetAllGenres().then(setGenres)
    },[])

        return (
            <>
                {genres?.map(genre => {
                    return <GenreCard key={genre.id} genre={genre} />
                 })}
            </>
        );
}