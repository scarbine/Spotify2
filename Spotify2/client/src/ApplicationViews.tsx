import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import App from "./App";
import { AlbumList } from "./components/Album/AlbumList";
import { ArtistList } from "./components/Artist/ArtistList";
import { SongList } from "./components/Song/SongList";

interface ApplicationViewsProps {}

export const ApplicationViews: React.FC<ApplicationViewsProps> = ({}) => {
  return (
    <>
      <main>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<App />} />
            <Route path="songs" element={<SongList />} />
            <Route path="artists" element={<ArtistList />} />
            <Route path="albums" element={<AlbumList />} />
          </Routes>
        </BrowserRouter>
      </main>
    </>
  );
};
