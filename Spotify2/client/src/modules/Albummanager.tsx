import React from "react";
import { getToken, } from "./AuthManager";



const apiUrl = "/api/album"

export const GetAllAlbums = () =>{
    return getToken().then((token: string) => {
        return fetch(apiUrl, {
          method: "GET",
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }).then((resp) => {
          if (resp.ok) {
            return resp.json();
          } else {
            throw new Error(
              "An unknown error occurred while trying to get Albums."
            );
          }
        });
      });
}