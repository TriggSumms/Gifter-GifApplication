import React, { useContext } from "react";
import React from "react";
import { Switch, Route, Redirect } from "react-router-dom";
import { UserProfileContext } from "../providers/UserProfileProvider";
import Login from "./Login";
import Register from "./Register";
import PostList from "./PostList";
import PostForm from "./PostForm";

export default function ApplicationViews() {
  const { isLoggedIn } = useContext(UserProfileContext);
  return (
    // <Switch>
    //   <Route path="/" exact>
    //     <PostList />
    //   </Route>

    //   <Route path="/posts/add">
    //     <PostForm />
    //   </Route>

    //   <Route path="/posts/:id">{/* TODO: Post Details Component */}</Route>
    // </Switch>
        <main>
        <Switch>
          <Route path="/" exact>
            {isLoggedIn ? <PostList /> : <Redirect to="/login" />}
          </Route>
  
          <Route path="/add">
            {isLoggedIn ? <PostForm /> : <Redirect to="/login" />}
          </Route>
  
          <Route path="/login">
            <Login />
          </Route>
  
          <Route path="/register">
            <Register />
          </Route>
        </Switch>
      </main>
  );
};

// export default ApplicationViews;