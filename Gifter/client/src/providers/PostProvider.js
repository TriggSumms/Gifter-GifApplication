import React, { useState, createContext, useContext } from "react";
import { UserProfileContext } from "./UserProfileProvider";

export const PostContext = createContext();

export function PostProvider(props) {
  const apiUrl = "/api/post";
  const { getToken } = useContext(UserProfileContext);
  const [posts, setPosts] = useState([]);

  // const getAllPosts = () => {
  //   return fetch("/api/post")
  //     .then((res) => res.json())
  //     .then(setPosts);
  // };

  const getAllPosts = () =>
    getToken().then((token) =>
      fetch(apiUrl, {
        method: "GET",
        headers: {
          Authorization: `Bearer ${token}`
        }
      }).then(resp => resp.json())
        .then(setPosts));


  // const addPost = (post) => {
  //   return fetch("/api/post", {
  //     method: "POST",
  //     headers: {
  //       "Content-Type": "application/json",
  //     },
  //     body: JSON.stringify(post),
  //   });
  // };

  const addPost = (post) =>
  getToken().then((token) =>
    fetch(apiUrl, {
      method: "POST",
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "application/json"
      },
      body: JSON.stringify(post)
    }).then(resp => {
      if (resp.ok) {
        return resp.json();
      }
      throw new Error("Unauthorized");
    }));
  
//   const searchAllPosts = () => {
//     return fetch("api/post/search")
//         .then((res) => res.json())
//         .then(setPosts);
// };

  return (
    <PostContext.Provider value={{ posts, getAllPosts, addPost }}>
      {props.children}
    </PostContext.Provider>
  );
};