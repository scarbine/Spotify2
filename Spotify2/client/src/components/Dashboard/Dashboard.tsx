import React from "react";
import { AlbumList } from "../Album/AlbumList";
import { SongList } from "../Song/SongList";
import { UserCard } from "../User/UserCard";
import { User } from "../../Interface/Interface";
import "./Dashboard.css"

interface DashboardProps {}

export const Dashboard: React.FC<DashboardProps> = ({}) => {

  const currentUser: User = {
    id: 1,
    firstName: "Sam",
    lastName: "C",
    email: "sc@me.com",
    firebaseId: "string",
    birthday: "11/18/20",
    userName: "sc",
    country: "US",
    state: "TN",
    city: "Nashville",
    profilePicUrl: "imageURL",
  };

  return (
    <>
      <div className="dashboard-container">
        <div className="left-container">
          <UserCard user={currentUser} />
        </div>
        <div className="center-container">
          <SongList />
        </div>
        <div className="right-container">
          <AlbumList />
        </div>
      </div>
    </>
  );
};
