import React from "react";
import "./App.css";
import { PostProvider } from "./providers/PostProvider";
import { UserProfileProvider } from "./providers/UserProfileProvider";
//import PostList from "./components/PostList";
//import PostForm from "./components/PostForm";
import ApplicationViews from "./components/ApplicationViews";
import { BrowserRouter as Router } from "react-router-dom";
import Header from "./components/Header";

function App() {
  return (
    <div className="App">
      <Router>
      <UserProfileProvider>
        <PostProvider>
        <Header /> 
         {/* <PostForm /> */}
          <ApplicationViews />
          
          {/* <PostList /> */}
        </PostProvider>
        </UserProfileProvider>
      </Router>
    </div>
  );
}

export default App;
