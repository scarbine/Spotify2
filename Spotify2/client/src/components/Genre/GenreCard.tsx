import React from 'react'
import { Genre } from "../../Interface/Interface";

interface GenreCardProps {
   genre: Genre;
}

export const GenreCard: React.FC<GenreCardProps> = ({genre}) => {
        return (
            <>
            <div>{genre.id}</div>
            <div>{genre.genre}</div>
            </>
        );
}